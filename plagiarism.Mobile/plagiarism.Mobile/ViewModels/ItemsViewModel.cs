using System.Collections.ObjectModel;
using System.Threading.Tasks;
using plagiarism.Mobile.Services;
using plagiarismModel.Requests.Users;

namespace plagiarism.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _userImagesService = new APIService("userImages");

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
        public async Task Init()
        {
            UserName = Global.LoggedUser.UserName;
        }
    }
}
