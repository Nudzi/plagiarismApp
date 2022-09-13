using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.UserAddresses;
using plagiarismModel.TableRequests.UserImages;
using plagiarismModel.TableRequests.Users;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _userAddressesService = new APIService("userAddresses");
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _userImagesService = new APIService("userImages");

        public UsersPackageTypes _usersPackageTypes = new UsersPackageTypes();
        public UsersPackageTypes UsersPackageTypesName
        {
            get { return _usersPackageTypes; }
            set { SetProperty(ref _usersPackageTypes, value); }
        }

        public PackageTypes _packageTypes = new PackageTypes();
        public PackageTypes PackageTypesName
        {
            get { return _packageTypes; }
            set { SetProperty(ref _packageTypes, value); }
        }

        public UserAddresses _userAddresses = new UserAddresses();
        public UserAddresses UserAddresses
        {
            get { return _userAddresses; }
            set { SetProperty(ref _userAddresses, value); }
        }

        public Users _user = new Users();
        public byte[] byteImage { get; set; }
        public Users User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _passwordConf = string.Empty;
        public string PasswordConf
        {
            get { return _passwordConf; }
            set { SetProperty(ref _passwordConf, value); }
        }

        bool _isVisiblePic = true;
        public bool VisiblePic
        {
            get { return _isVisiblePic; }
            set { SetProperty(ref _isVisiblePic, value); }
        }

        bool _isUser = true;
        public bool IsUser
        {
            get { return _isUser; }
            set { SetProperty(ref _isUser, value); }
        }

        public async Task Init()
        {
            try
            {
                User = Global.LoggedUser;
                var user = await _usersService.GetById<Users>(User.Id);

                UserImagesSearchRequest request = new UserImagesSearchRequest
                {
                    UserId = user.Id
                };
                var image = await _userImagesService.Get<List<UserImages>>(request);
                if (image.Count == 0)
                {
                    VisiblePic = false;
                }
                else
                {
                    Image = image[0].Image;
                    VisiblePic = Image.Length != 0;
                }

                IsUser = User.OfficialName.Length == 0;

                var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
                {
                    UserId = user.Id
                };
                var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

                var packageTypes = await _packageTypesService.GetById<PackageTypes>(usersPackageTypes[0].PackageTypeId);
                PackageTypesName = packageTypes;
                UsersPackageTypesName = usersPackageTypes[0];

                var userAddress = await _userAddressesService.GetById<UserAddresses>(User.UserAddressId);

                UserAddresses = userAddress;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }

        public async Task SaveUserProfil(Image resultImage)
        {
            try
            {
                var gettedUser = Global.LoggedUser;

                var userInts = new List<int>();
                if (gettedUser.UserTypes == null)
                {
                    userInts.Add((int)plagiarismModel.Enums.UserTypes.User);
                }
                else
                {
                    foreach (var item in gettedUser.UserTypes)
                        userInts.Add(item.UserTypeId);
                }
                UsersInsertRequest request = new UsersInsertRequest
                {
                    Id = gettedUser.Id,
                    Email = gettedUser.Email,
                    OfficialName = gettedUser.OfficialName,
                    Status = true,
                    FirstName = gettedUser.FirstName,
                    LastName = gettedUser.LastName,
                    Password = Password,
                    PasswordConfirmation = PasswordConf,
                    Telephone = gettedUser.Telephone,
                    UserName = gettedUser.UserName,
                    UserTypes = userInts
                };


                if (request != null)
                {
                    if (!User.FirstName.Equals(""))
                        request.FirstName = User.FirstName;

                    if (!User.LastName.Equals(""))
                        request.LastName = User.LastName;

                    if (!User.Telephone.Equals(""))
                        request.Telephone = User.Telephone;

                    if (!User.OfficialName.Equals(""))
                        request.OfficialName = User.OfficialName;

                    request.UserAddressId = Global.LoggedUser.UserAddressId;
                    await _usersService.Update<Users>(request.Id, request);
                    var glob = await _usersService.GetById<Users>(request.Id);
                    Global.LoggedUser = glob;

                    if (resultImage.Source != null)
                    {
                        UserImagesSearchRequest imagesSearchRequest = new UserImagesSearchRequest
                        {
                            UserId = gettedUser.Id
                        };
                        var image = await _userImagesService.Get<List<UserImages>>(imagesSearchRequest);

                        UserImagesUpsertRequest userImagesUpsertRequest = new UserImagesUpsertRequest
                        {
                            Image = byteImage,
                            ImageThumb = byteImage,
                            UserId = gettedUser.Id
                        };

                        if (image.Count == 0)
                        {
                            await _userImagesService.Insert<UserImages>(userImagesUpsertRequest);
                        }
                        else
                        {
                            await _userImagesService.Update<UserImages>(image[0].Id, userImagesUpsertRequest);
                        }
                    }

                    var userAddresses = new UserAddressesUpsertRequest
                    {
                        Id = glob.UserAddressId,
                        City = UserAddresses.City,
                        State = UserAddresses.State,
                        Street = UserAddresses.Street,
                        ZipCode = UserAddresses.ZipCode
                    };

                    await _userAddressesService.Update<UserAddresses>((int)glob.UserAddressId, userAddresses);
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfuly edited! ", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Cannot save right now, try later!", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}