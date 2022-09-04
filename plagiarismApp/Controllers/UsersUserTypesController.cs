using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.TableRequests.UsersUserTypes;

namespace plagiarismApp.Controllers
{
    public class UsersUserTypesController : BaseCRUDController<UsersUserTypes, UsersUserTypesSearchRequest, UsersUserTypesUpsertRequest, UsersUserTypesUpsertRequest>
    {
        public UsersUserTypesController(ICRUDService<UsersUserTypes, UsersUserTypesSearchRequest, UsersUserTypesUpsertRequest, UsersUserTypesUpsertRequest> service) : base(service)
        {

        }
    }
}
