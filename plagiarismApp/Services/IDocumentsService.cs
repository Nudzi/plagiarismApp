using plagiarismModel.TableRequests.Documents;
using System.Collections.Generic;

namespace plagiarismApp.Services
{
    public interface IDocumentsService
    {
        List<plagiarismModel.Documents> Get(DocumentsSearchRequest request);
        plagiarismModel.Documents GetById(int id);
        plagiarismModel.Documents Insert(DocumentsUpsertRequest request);
        plagiarismModel.Documents Update(int id, DocumentsUpsertRequest request);
        List<plagiarismModel.Documents> Plagiarism(DocumentsSearchRequest request);
    }
}
