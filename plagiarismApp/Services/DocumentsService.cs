using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.TableRequests.Documents;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly plagiarismContext _context;
        private readonly IMapper _mapper;
        public DocumentsService(plagiarismContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<plagiarismModel.Documents> Get(DocumentsSearchRequest request)
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

        public plagiarismModel.Documents GetById(int id)
        {
            var entity = _context.Documents.Find(id);

            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public plagiarismModel.Documents Insert(DocumentsUpsertRequest request)
        {
            var entity = _mapper.Map<Documents>(request);

            _context.Documents.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public plagiarismModel.Documents Update(int id, DocumentsUpsertRequest request)
        {
            var entity = _context.Documents.Find(id);
            _context.Documents.Attach(entity);
            _context.Documents.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public List<plagiarismModel.Documents> Plagiarism(DocumentsSearchRequest request)
        {
            var query = _context.Set<Documents>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.ToLower().Contains(request.Text.ToLower()));
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Documents>>(list);
        }
    }
}
