using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.Requests.PackageTypes;
using plagiarismModel.Requests.UserAddresses;
using plagiarismModel.Requests.UserImages;
using plagiarismModel.Requests.Users;
using plagiarismModel.Requests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        private readonly APIService _service = new APIService("users");
        private readonly APIService _addressesService = new APIService("userAddresses");
        private readonly APIService _userImagesService = new APIService("userImages");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _packageTypesService = new APIService("packageTypes");

        public ObservableCollection<PackageTypesRegistrationSearchRequest> PackageTypesList { get; set; } = new ObservableCollection<PackageTypesRegistrationSearchRequest>();

        public ObservableCollection<string> CultureList { get; set; } = new ObservableCollection<string>();

        PackageTypesRegistrationSearchRequest _selectedPackageTypes = null;
        public Users User { get; set; }

        public PackageTypesRegistrationSearchRequest SelectedPackageTypes
        {
            get { return _selectedPackageTypes; }
            set { SetProperty(ref _selectedPackageTypes, value); }
        }

        string _firstName = string.Empty;
        public byte[] byteImage { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        string _officialName = string.Empty;
        public string OfficialName
        {
            get { return _officialName; }
            set { SetProperty(ref _officialName, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _telephone = string.Empty;
        public string Telephone
        {
            get { return _telephone; }
            set { SetProperty(ref _telephone, value); }
        }
        string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
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
        string _state = string.Empty;
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }
        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        string _zipCode = string.Empty;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        bool _isUser = true;
        public bool IsUser
        {
            get { return _isUser; }
            set { SetProperty(ref _isUser, value); }
        }

        public async Task Init()
        {
            await addPackageTypes();
            populateStates();
        }
        public async Task addPackageTypes()
        {
            if (PackageTypesList.Count == 0)
            {
                var packageTypesListDB = await _packageTypesService.Get<List<PackageTypes>>(null);
                foreach (var item in packageTypesListDB)
                {
                    PackageTypesList.Add(new PackageTypesRegistrationSearchRequest(item.Name, item.Price.ToString(),
                        item.Id));
                }
                SelectedPackageTypes = PackageTypesList[0];
            }
        }

        public decimal buildPackageDisc(string package)
        {
            if (PackageTypesTypes.Basic.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Basic;
            }
            if (PackageTypesTypes.Silver.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Silver;
            }
            else
            {
                return (decimal)PackageTypesDisc.Premium;
            }
        }

        public DateTime buildPackageExpDate(string package)
        {
            if (PackageTypesExpDate.Basic.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Basic));
            if (PackageTypesExpDate.Silver.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Silver));
            else return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Premium));
        }

        public async Task Register()
        {
            try
            {
                List<int> userTypes = new List<int>();
                if (!IsUser) 
                    userTypes.Add((int)plagiarismModel.Enums.UserTypes.Institution);
                else
                    userTypes.Add((int)plagiarismModel.Enums.UserTypes.User);

                UserAddressesUpsertRequest userAddressesUpserRequest = new UserAddressesUpsertRequest
                {
                    Street = Street,
                    City = City,
                    State = State,
                    ZipCode = ZipCode
                };
                var address = await _addressesService.Insert<UserAddresses>(userAddressesUpserRequest);


                UsersInsertRequest request = new UsersInsertRequest
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    OfficialName = OfficialName,
                    Password = Password,
                    PasswordConfirmation = PasswordConf,
                    Status = true,
                    Telephone = Telephone,
                    UserName = UserName,
                    UserTypes = userTypes,
                    UserAddressId = address.Id
                };

                if (IsUser)
                {
                    request.OfficialName = "";
                }
                else
                {
                    request.FirstName = "";
                    request.FirstName = "";
                }

                var user = await _service.Insert<Users>(request);
                Global.LoggedUser = user;

                UserImagesUpsertRequest userImagesUpsertRequest = new UserImagesUpsertRequest
                {
                    Image = byteImage,
                    ImageThumb = byteImage,
                    UserId = user.Id
                };

                await _userImagesService.Insert<UserImages>(userImagesUpsertRequest);
                
                UsersPackageTypesUpsertRequest usersPackageTypesUpsertRequest = new UsersPackageTypesUpsertRequest
                {
                    UserId = user.Id,
                    IsActive = true,
                    PackageTypeId = SelectedPackageTypes.PackageTypeId,
                    Discount = buildPackageDisc(SelectedPackageTypes.Name),
                    ExpiredDate = buildPackageExpDate(SelectedPackageTypes.Name),
                    CreatedDate = DateTime.Now
                };


                Application.Current.MainPage = new MainPage(user);

                await _usersPackageTypesService.Insert<UsersPackageTypes>(usersPackageTypesUpsertRequest);

                await Application.Current.MainPage.DisplayAlert("Success", "Welcome new User " + user.UserName, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public void populateStates()
        {
            CultureInfo[] getCultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var getCulture in getCultureInfos)
            {
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);

                if (!(CultureList.Contains(getRegionInfo.EnglishName)))
                {
                    CultureList.Add(getRegionInfo.EnglishName);
                }
            }
        }
    }
}