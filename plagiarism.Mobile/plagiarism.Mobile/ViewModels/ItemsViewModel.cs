using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace plagiarism.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _userImagesService = new APIService("userImages");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");

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

        public async Task Init()
        {
            UserName = Global.LoggedUser.UserName;

            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = Global.LoggedUser.Id
            };
            var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            var pkcgUs = usersPackageTypes[0].PackageTypeId;

            if (pkcgUs.Equals((int)PackageTypesTypes.Premium))
            {
                IsPremimum = true;
            }
        }
    }
}
