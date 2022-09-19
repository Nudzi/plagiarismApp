using plagiarism.Mobile.ViewModels;

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

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}
