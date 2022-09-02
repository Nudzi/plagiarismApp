using plagiarismModel;
using plagiarismApp.Services;
using plagiarismModel.Requests.Documents;

namespace plagiarismApp.Controllers
{
    public class DocumentsController : BaseCRUDController<Documents, DocumentsSearchRequest, DocumentsUpsertRequest, DocumentsUpsertRequest>
    {
        public DocumentsController(ICRUDService<Documents, DocumentsSearchRequest, DocumentsUpsertRequest, DocumentsUpsertRequest> service) : base(service)
        {

        }
    }
}
