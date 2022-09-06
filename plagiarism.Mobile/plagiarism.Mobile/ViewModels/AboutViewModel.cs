﻿using plagiarismModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }
        public Users User { get; set; }
        public ICommand OpenWebCommand { get; }

    }
}
