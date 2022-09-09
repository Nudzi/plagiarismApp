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
            await Application.Current.MainPage.DisplayAlert("Success", "Payment in the procces.", "OK");
            Application.Current.MainPage = new MainPage(Global.LoggedUser);
        }
    }
}
