using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.Requests.UserAddresses;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class UserAddressesService : BaseCRUDService<plagiarismModel.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest, UserAddresses>
    {
        public UserAddressesService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.UserAddresses> Get(UserAddressesSearchRequest request)
        {
            var query = _context.Set<UserAddresses>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.State))
            {
                query = query.Where(x => x.State.StartsWith(request.State));
            }
            if (!string.IsNullOrWhiteSpace(request?.City))
            {
                query = query.Where(x => x.City.StartsWith(request.City));
            }
            if (!string.IsNullOrWhiteSpace(request?.Street))
            {
                query = query.Where(x => x.Street.StartsWith(request.Street));
            }
            if (!string.IsNullOrWhiteSpace(request?.ZipCode))
            {
                query = query.Where(x => x.ZipCode.StartsWith(request.ZipCode));
            }
            if (request?.Id.HasValue == true)
            {
                query = query.Where(x => x.Id == request.Id);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.UserAddresses>>(list);
        }
    }
}
