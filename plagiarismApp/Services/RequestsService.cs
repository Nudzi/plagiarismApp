using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.TableRequests.Requests;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly plagiarismContext _context;
        private readonly IMapper _mapper;
        public RequestsService(plagiarismContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public plagiarismModel.Requests Delete(int id)
        {
            var entity = _context.Requests.Find(id);
            if (entity != null)
            {
                _context.Requests.Remove(entity);
                _context.SaveChanges();
                return _mapper.Map<plagiarismModel.Requests>(entity);
            }
            else
            {
                return null;
            }
        }

        public List<plagiarismModel.Requests> Get(RequestsSearchRequest request)
        {
            var query = _context.Requests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Author))
            {
                query = query.Where(x => x.Author.StartsWith(request.Author));
            }
            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title));
            }
            if (!string.IsNullOrWhiteSpace(request?.Publisher))
            {
                query = query.Where(x => x.Publisher.StartsWith(request.Publisher));
            }
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            var list = query.ToList();
            return _mapper.Map<List<plagiarismModel.Requests>>(list);
        }

        public plagiarismModel.Requests GetById(int id)
        {
            var entity = _context.Requests.Find(id);

            return _mapper.Map<plagiarismModel.Requests>(entity);
        }

        public plagiarismModel.Requests Insert(RequestsUpsertRequest request)
        {
            var entity = _mapper.Map<Requests>(request);

            _context.Requests.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();
            return _mapper.Map<plagiarismModel.Requests>(entity);
        }
        public plagiarismModel.Requests Update(int id, RequestsUpsertRequest request)
        {
            var entity = _context.Requests.Find(id);
            _context.Requests.Attach(entity);
            _context.Requests.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<plagiarismModel.Requests>(entity);//return our model, than go to controller
        }

    }
}
