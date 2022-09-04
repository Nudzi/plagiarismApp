using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.TableRequests.UserImages;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class UserImagesService : BaseCRUDService<plagiarismModel.UserImages, UserImagesSearchRequest, UserImagesUpsertRequest, UserImagesUpsertRequest, UserImages>
    {
        public UserImagesService(plagiarismContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<plagiarismModel.UserImages> Get(UserImagesSearchRequest request)
        {
            var query = _context.Set<UserImages>().AsQueryable();
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.UserImages>>(list);
        }
    }
}
