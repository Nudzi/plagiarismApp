using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using plagiarismModel.Requests.UserAddresses;
using plagiarismModel.Requests.UserImages;
using plagiarismModel.Requests.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        private readonly APIService _service = new APIService("users");
        private readonly APIService _addressesService = new APIService("userAddresses");
        private readonly APIService _userImagesService = new APIService("userImages");
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

        public async Task Register()
        {
            try
            {
                List<int> userTypes = new List<int>();
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
                    Password = Password,
                    PasswordConfirmation = PasswordConf,
                    Status = true,
                    Telephone = Telephone,
                    UserName = UserName,
                    UserTypes = userTypes
                };

                var user = await _service.Insert<Users>(request);
                Global.LoggedUser = user;

                UserImagesSearchRequest imagesSearchRequest = new UserImagesSearchRequest
                {
                    UserId = user.Id
                };
                UserImagesUpsertRequest userImagesUpsertRequest = new UserImagesUpsertRequest
                {
                    Image = byteImage,
                    ImageThumb = byteImage,
                    UserId = user.Id
                };
                Application.Current.MainPage = new MainPage(user);

                await _userImagesService.Insert<UserImages>(userImagesUpsertRequest);
                await Application.Current.MainPage.DisplayAlert("Success", "Welcome new User!", "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }
    }
}