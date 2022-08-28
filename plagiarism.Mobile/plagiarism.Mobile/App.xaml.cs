using plagiarism.Mobile.Views;
using Xamarin.Forms;

namespace plagiarism.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage()
            MainPage = new NavigationPage(new LoginPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
