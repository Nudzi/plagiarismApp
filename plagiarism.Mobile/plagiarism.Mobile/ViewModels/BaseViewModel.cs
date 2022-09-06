using plagiarism.Mobile.Models;
using plagiarism.Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static Regex visaRegex = new Regex(@"^4[0-9]{6,}$");
        public static Regex masterRegex = new Regex(@"^5[1-5][0-9]{5,}|222[1-9][0-9]{3,}|22[3-9][0-9]{4,}|2[3-6][0-9]{5,}|27[01][0-9]{4,}|2720[0-9]{3,}$");
        public static Regex dinnersRegex = new Regex(@"^3(?:0[0-5]|[68][0-9])[0-9]{4,}$");
        public static Regex discoverRegex = new Regex(@"^6(?:011|5[0-9]{2})[0-9]{3,}$");
        public static Regex jcbRegex = new Regex(@"^(?:2131|1800|35[0-9]{3})[0-9]{3,}$");
        public static Regex amexRegex = new Regex(@"^3[47][0-9]{5,}$");
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}