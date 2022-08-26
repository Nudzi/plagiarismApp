using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.Requests.UserAddresses;

namespace plagiarismApp.Controllers
{
    public class UserAddressesController : BaseCRUDController<UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest>
    {
        public UserAddressesController(ICRUDService<UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest> service) : base(service)
        {

        }
    }
}
