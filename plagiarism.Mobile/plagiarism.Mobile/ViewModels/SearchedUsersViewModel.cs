using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.UserImages;
using plagiarismModel.TableRequests.Users;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace plagiarism.Mobile.ViewModels
{
    public class SearchedUsersViewModel : BaseViewModel
    {
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _userImagesService = new APIService("userImages");

        public ObservableCollection<UsersSearchList> UsersSearchedList { get; set; } = new ObservableCollection<UsersSearchList>();

        public SearchedUsersViewModel()
        {
        }
        public string SearchPhone { get; set; }
        public async Task Init()
        {
            UsersSearchRequest usersSearchRequest = new UsersSearchRequest
            {
                PhoneNumber = SearchPhone
            };

            UsersSearchedList.Clear();
            var users = await _usersService.Get<List<Users>>(usersSearchRequest);

            List<Users> finalUsers = new List<Users>();


            foreach (var item in finalUsers)
            {
                UserImagesSearchRequest request = new UserImagesSearchRequest
                {
                    UserId = item.Id
                };
                var userImages = await _userImagesService.Get<List<UserImages>>(request);
                UsersSearchList tmp = new UsersSearchList
                {
                    UserId = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Image = userImages[0].Image
                };
                UsersSearchedList.Add(tmp);
            }
        }

        public async Task AddFriend(UsersSearchList item)
        {
        }
    }
}