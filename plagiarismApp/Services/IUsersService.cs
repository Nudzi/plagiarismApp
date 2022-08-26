using plagiarismModel.Requests.Users;
using System.Collections.Generic;

namespace plagiarismApp.Services
{
    public interface IUsersService
    {
        List<plagiarismModel.Users> Get(UsersSearchRequest request);
        plagiarismModel.Users GetById(int id);
        plagiarismModel.Users Insert(UsersInsertRequest request);
        plagiarismModel.Users Update(int id, UsersInsertRequest request);
        plagiarismModel.Users Authentication(string username, string pass);
    }
}
