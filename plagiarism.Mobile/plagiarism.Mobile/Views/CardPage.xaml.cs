using plagiarism.Mobile.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        CreditCardPageViewModel model = null;
        public CardPage()
        {
            InitializeComponent();
            BindingContext = model = new CreditCardPageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

            if (Global.UsersPackageType.PackageTypeId == 4)
            {
                noPkcgError.IsVisible = true;
                expiredDays.IsVisible = false;
            }
            else
            {
                expiredDays.IsVisible = true;
                noPkcgError.IsVisible = false;
            }
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (model != null)
            {
                await model.Init();
            }
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Launcher.OpenAsync("https://www.paypal.com/ba/signin");
            Application.Current.MainPage = new MainPage(Global.LoggedUser);
        }

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {
            if (validateCardNumber() && validateCardExDate() && validateCVV())
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Payment in the procces.", "OK");
                await model.ExtendPackage();
                Application.Current.MainPage = new MainPage(Global.LoggedUser);
            }
        }

        private bool validateCVV()
        {
            if (model.CardCvv == "")
            {
                CVVError.Text = "Must insert Card CVV!";
                CVVError.IsVisible = true;
                return false;
            }
            else
            {
                CVVError.IsVisible = false;
                CVVError.Text = "";
                return true;
            }
        }

        private bool validateCardExDate()
        {
            if (model.CardExpirationDate == "")
            {
                CardExDate.Text = "Must insert Card Expiration Date!";
                CardExDate.IsVisible = true;
                return false;
            }
            else
            {
                CardExDate.IsVisible = false;
                CardExDate.Text = "";
                return true;
            }
        }

        private bool validateCardNumber()
        {
            if (model.CardNumber == "")
            {
                CardNumberError.Text = "Must Card Number!";
                CardNumberError.IsVisible = true;
                return false;
            }
            else
            {
                CardNumberError.IsVisible = false;
                CardNumberError.Text = "";
                return true;
            }
        }
    }
}
