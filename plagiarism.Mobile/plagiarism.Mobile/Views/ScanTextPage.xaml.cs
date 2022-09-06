using plagiarism.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanTextPage : ContentPage
    {
        ScanViewModel model = null;
        public ScanTextPage()
        {
            InitializeComponent();
            BindingContext = model = new ScanViewModel { };
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            bool isError = await model.CheckAllowedTextSize();
            textError.IsVisible = isError;
        }
    }
}
