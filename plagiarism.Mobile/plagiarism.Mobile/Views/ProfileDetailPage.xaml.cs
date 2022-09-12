using plagiarism.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetailPage : ContentPage
    {
        readonly ProfileViewModel model = null;
        public ProfileDetailPage()
        {
            InitializeComponent();
            BindingContext = model = new ProfileViewModel { };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }
    }
}
