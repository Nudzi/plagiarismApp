using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.Requests.PackageTypes;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class PackageTypesService : BaseService<plagiarismModel.PackageTypes, PackageTypesSearchRequest, PackageTypes>
    {
        public PackageTypesService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.PackageTypes> Get(PackageTypesSearchRequest request)
        {
            var query = _context.Set<PackageTypes>().AsQueryable();
            if (request?.Id.HasValue == true)
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.PackageTypes>>(list);
        }
    }
}
