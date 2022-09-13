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

            if (viewModel.IsValid)
            {
                docScanLbl.IsEnabled = viewModel.IsPremimum;
                docScanBttn.IsEnabled = viewModel.IsPremimum;
                docScanError.IsVisible = !viewModel.IsPremimum;
            }
            else
            {
                docScanBttn.IsEnabled = viewModel.IsValid;
                scanError.IsVisible = true;
                docScanError.IsVisible = false;
                txtScan.IsEnabled = viewModel.IsValid;
            }

            if (Global.JustRegisterNoPackage)
            {
                wholeStack.IsVisible = false;
                errorPkcg.IsVisible = true;
            }
            else
            {
                wholeStack.IsVisible = true;
                errorPkcg.IsVisible = false;
            }
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
