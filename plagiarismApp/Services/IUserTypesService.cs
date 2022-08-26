using System.Collections.Generic;

namespace plagiarismApp.Services
{
    public interface IUserTypesService
    {
        List<plagiarismModel.UserTypes> Get();
        plagiarismModel.UserTypes GetById(int id);
        plagiarismModel.UserTypes isAdmin(int UlogaId);
    }
}
