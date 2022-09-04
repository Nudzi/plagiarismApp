using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.TableRequests.Documents;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class DocumentsService : BaseCRUDService<plagiarismModel.Documents, DocumentsSearchRequest, DocumentsUpsertRequest, DocumentsUpsertRequest, Documents>
    {
        public DocumentsService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.Documents> Get(DocumentsSearchRequest request)
        {
            var query = _context.Set<Documents>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.StartsWith(request.Text));
            }
            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title));
            }
            if (!string.IsNullOrWhiteSpace(request?.Author))
            {
                query = query.Where(x => x.Author.StartsWith(request.Author));
            }
            if (!string.IsNullOrWhiteSpace(request?.Publisher))
            {
                query = query.Where(x => x.Publisher.StartsWith(request.Publisher));
            }
            if (!string.IsNullOrWhiteSpace(request?.Type))
            {
                query = query.Where(x => x.Type.StartsWith(request.Type));
            }
            if (!string.IsNullOrWhiteSpace(request?.Extension))
            {
                query = query.Where(x => x.Extension.StartsWith(request.Extension));
            }


            // ints
            if (request?.Id.HasValue == true)
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (request?.PackageTypeId.HasValue == true)
            {
                query = query.Where(x => x.PackageTypeId == request.PackageTypeId);
            }
            if (request?.TimeUsed.HasValue == true)
            {
                query = query.Where(x => x.TimeUsed == request.TimeUsed);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Documents>>(list);
        }
    }
}
