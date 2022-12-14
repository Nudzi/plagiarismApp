using plagiarismApp.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.PackageTypes;

namespace plagiarismApp.Controllers
{
    public class PackageTypesController : BaseController<PackageTypes, PackageTypesSearchRequest>
    {
        public PackageTypesController(IService<PackageTypes, PackageTypesSearchRequest> service) : base(service)
        {

        }
    }
}
