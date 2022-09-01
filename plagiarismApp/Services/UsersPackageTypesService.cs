using AutoMapper;
using Microsoft.EntityFrameworkCore;
using plagiarismApp.Database;
using plagiarismModel.Requests.UsersPackageTypes;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class UsersPackageTypesService : BaseCRUDService<plagiarismModel.UsersPackageTypes, UsersPackageTypesSearchRequest, UsersPackageTypesUpsertRequest, UsersPackageTypesUpsertRequest, UsersPackageTypes>
    {
        public UsersPackageTypesService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.UsersPackageTypes> Get(UsersPackageTypesSearchRequest request)
        {
            var query = _context.Set<UsersPackageTypes>().Include(x=> x.PackageType).AsQueryable();
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (request?.PackageTypeId.HasValue == true)
            {
                query = query.Where(x => x.PackageTypeId == request.PackageTypeId);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.UsersPackageTypes>>(list);
        }
    }
}
