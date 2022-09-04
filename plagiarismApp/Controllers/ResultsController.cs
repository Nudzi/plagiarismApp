using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.TableRequests.Results;

namespace plagiarismApp.Controllers
{
    public class ResultsController : BaseCRUDController<Results, ResultsSearchRequest, ResultsUpsertRequest, ResultsUpsertRequest>
    {
        public ResultsController(ICRUDService<Results, ResultsSearchRequest, ResultsUpsertRequest, ResultsUpsertRequest> service) : base(service)
        {

        }
    }
}
