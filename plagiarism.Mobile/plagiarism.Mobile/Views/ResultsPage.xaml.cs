using plagiarism.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        ResultsViewModel model = null;
        public ResultsPage()
        {
            InitializeComponent();
            BindingContext = model = new ResultsViewModel { };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage(Global.LoggedUser);
        }
    }
}
