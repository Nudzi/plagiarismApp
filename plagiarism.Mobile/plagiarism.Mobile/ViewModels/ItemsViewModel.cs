using plagiarismModel.Enums;
using System;

namespace plagiarism.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        string _username = string.Empty;
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public ItemsViewModel()
        {
            Title = "Browse";
        }

        bool _isPremimum = false;
        public bool IsPremimum
        {
            get { return _isPremimum; }
            set { SetProperty(ref _isPremimum, value); }
        }

        bool _isValid = false;
        public bool IsValid
        {
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }

        public void Init()
        {
            UserName = Global.LoggedUser.UserName;

            var pkcgUs = Global.UsersPackageType;

            if (pkcgUs != null)
            {
                if (pkcgUs.PackageTypeId.Equals((int)PackageTypesTypes.Premium))
                {
                    IsPremimum = true;
                }

                if (DateTime.Compare(pkcgUs.ExpiredDate, DateTime.Now) > 0)
                {
                    IsValid = true;
                }
            }
        }
    }
}
