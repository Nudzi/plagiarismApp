using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.Requests.UsersPackageTypes;

namespace plagiarismApp.Controllers
{
    public class UsersPackageTypesController : BaseCRUDController<UsersPackageTypes, UsersPackageTypesSearchRequest, UsersPackageTypesUpsertRequest, UsersPackageTypesUpsertRequest>
    {
        public UsersPackageTypesController(ICRUDService<UsersPackageTypes, UsersPackageTypesSearchRequest, UsersPackageTypesUpsertRequest, UsersPackageTypesUpsertRequest> service) : base(service)
        {

        }
    }
}
