using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.Requests.Institutions;

namespace plagiarismApp.Controllers
{
    public class InstitutionsController : BaseCRUDController<Institutions, InstitutionsSearchRequest, InstitutionsUpsertRequest, InstitutionsUpsertRequest>
    {
        public InstitutionsController(ICRUDService<Institutions, InstitutionsSearchRequest, InstitutionsUpsertRequest, InstitutionsUpsertRequest> service) : base(service)
        {

        }
    }
}
