using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.Requests.Institutions;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class InstitutionsService : BaseCRUDService<plagiarismModel.Institutions, InstitutionsSearchRequest, InstitutionsUpsertRequest, InstitutionsUpsertRequest, Institutions>
    {
        public InstitutionsService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.Institutions> Get(InstitutionsSearchRequest request)
        {
            var query = _context.Set<Institutions>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.UserName))
            {
                query = query.Where(x => x.UserName.StartsWith(request.UserName));
            }
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email));
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Institutions>>(list);
        }
    }
}
