using plagiarismApp.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.UserImages;

namespace plagiarismApp.Controllers
{
    public class UserImagesController : BaseCRUDController<UserImages, UserImagesSearchRequest, UserImagesUpsertRequest, UserImagesUpsertRequest>
    {
        public UserImagesController(ICRUDService<UserImages, UserImagesSearchRequest, UserImagesUpsertRequest, UserImagesUpsertRequest> service) : base(service)
        {

        }
    }
}
