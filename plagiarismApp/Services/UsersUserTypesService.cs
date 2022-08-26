using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.Requests.UsersUserTypes;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class UsersUserTypesService : BaseCRUDService<plagiarismModel.UsersUserTypes, UsersUserTypesSearchRequest, UsersUserTypesUpsertRequest, UsersUserTypesUpsertRequest, UsersUserTypes>
    {
        public UsersUserTypesService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.UsersUserTypes> Get(UsersUserTypesSearchRequest request)
        {
            var query = _context.Set<UsersUserTypes>().AsQueryable();
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (request?.UserTypeId.HasValue == true)
            {
                query = query.Where(x => x.UserTypeId == request.UserTypeId);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.UsersUserTypes>>(list);
        }
    }
}
