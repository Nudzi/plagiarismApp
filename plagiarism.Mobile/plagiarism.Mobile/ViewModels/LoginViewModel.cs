using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("users");
        private readonly APIService _userAddressesService = new APIService("userAddresses");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            try
            {
                Users user = await _service.Authentication<Users>(Username, Password);
                if (user != null)
                {
                    Users userCheck = await _service.GetById<Users>(user.Id);
                    if (userCheck.Status == false)
                    {
                        await TextToSpeech.SpeakAsync("There is problem with your account, you can contact us for further details!");
                        await Application.Current.MainPage.DisplayAlert("Error", "There is problem with your account, you can contact us for further details!", "OK");
                        IsBusy = false;
                        return;
                    }
                    Global.LoggedUser = userCheck;

                    await Application.Current.MainPage.DisplayAlert("Success", "Welcome " + user.UserName, "OK");
                    Application.Current.MainPage = new MainPage(userCheck);
                }
                else
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
