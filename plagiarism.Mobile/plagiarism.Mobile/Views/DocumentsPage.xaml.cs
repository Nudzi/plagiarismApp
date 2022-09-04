using plagiarism.Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsPage : ContentPage
    {
        DocumentsViewModel model = null;
        public DocumentsPage()
        {
            InitializeComponent();
            BindingContext = model = new DocumentsViewModel { };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void searchBarTitle_SearchButtonPressed(object sender, EventArgs e)
        {
            await model.SearchByTitle(searchBarTitle.Text);
        }

        private async void searchBarAuthor_SearchButtonPressed(object sender, EventArgs e)
        {
            await model.SearchByAuthor(searchBarAuthor.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DocumentsNewPage());
        }
    }
}
