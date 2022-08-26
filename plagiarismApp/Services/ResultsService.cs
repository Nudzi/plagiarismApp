using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.Requests.Results;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class ResultsService : BaseCRUDService<plagiarismModel.Results, ResultsSearchRequest, ResultsUpsertRequest, ResultsUpsertRequest, Results>
    {
        public ResultsService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.Results> Get(ResultsSearchRequest request)
        {
            var query = _context.Set<Results>().AsQueryable();
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (request?.InstitutionId.HasValue == true)
            {
                query = query.Where(x => x.InstitutionId == request.InstitutionId);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Results>>(list);
        }
    }
}
