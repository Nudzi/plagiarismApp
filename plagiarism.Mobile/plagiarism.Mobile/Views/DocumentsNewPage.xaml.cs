using plagiarism.Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsNewPage : ContentPage
    {
        DocumentsViewModel model = null;
        public DocumentsNewPage()
        {
            InitializeComponent();
            BindingContext = model = new DocumentsViewModel { };
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            bool isChecked = isTextChecked.IsChecked;
            if (isChecked)
            {
                textText.IsVisible = true;
                entryText.IsVisible = true;
                textDocument.IsVisible = false;
                entryDoc.IsVisible = false;
            }
            else
            {
                textText.IsVisible = false;
                entryText.IsVisible = false;
                textDocument.IsVisible = true;
                entryDoc.IsVisible = true;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.SaveRequest();
        }
    }
}
