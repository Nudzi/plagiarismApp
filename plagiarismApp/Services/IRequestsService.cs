using plagiarismModel.TableRequests.Requests;
using System.Collections.Generic;

namespace plagiarismApp.Services
{
    public interface IRequestsService
    {
        List<plagiarismModel.Requests> Get(RequestsSearchRequest request);
        plagiarismModel.Requests GetById(int id);
        plagiarismModel.Requests Insert(RequestsUpsertRequest request);
        plagiarismModel.Requests Update(int id, RequestsUpsertRequest request);
        plagiarismModel.Requests Delete(int id);
    }
}
