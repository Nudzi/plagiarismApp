using plagiarismApp.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.UserAddresses;

namespace plagiarismApp.Controllers
{
    public class UserAddressesController : BaseCRUDController<UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest>
    {
        public UserAddressesController(ICRUDService<UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest> service) : base(service)
        {

        }
    }
}
