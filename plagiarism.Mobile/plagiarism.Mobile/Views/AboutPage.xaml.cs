using plagiarism.Mobile.ViewModels;
using plagiarismModel;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel model = null;
        public AboutPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new AboutViewModel { User = user };
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var latitude = 43.6547702;
            var longitude = 17.9548099;
            var name = "Konjic Kolonija 1";
            var location = new Location(latitude, longitude);
            var options = new MapLaunchOptions
            {
                Name = name
            };
            try
            {
                await Map.OpenAsync(location, options);

            }
            catch (FeatureNotSupportedException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var number = "123456789";
                PhoneDialer.Open(number);
            }
            catch (FeatureNotSupportedException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                var subject = "Your Subject!";
                var body = "Your Body!";
                List<string> list = new List<string>();
                var recipients = "chat@gmail.com";
                list.Add(recipients);
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = list
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await Application.Current.MainPage.DisplayAlert("Error", fbsEx.Message, "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}