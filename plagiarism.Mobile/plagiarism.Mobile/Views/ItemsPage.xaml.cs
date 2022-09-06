using plagiarism.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }

        private async void Scan_Doc(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScanDocPage());
        }

        private async void Scan_Text(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScanTextPage());
        }
    }
}
