using plagiarism.Mobile.ViewModels;
using System;
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

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var minLength = model.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            if (minLength < 3)
            {
                textError.IsVisible = true;
                model.TextError = "Please insert more than 3 words.";
                return;
            }
            if (!isError)
            {
                await model.CheckPlagiarism();
            }
        }
    }
}
