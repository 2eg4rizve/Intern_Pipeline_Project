
using InternPipeline.Entities.RequestEntity;
using InternPipeline.Entities.ResponseEntity;

namespace InternPipeline.Managers.Interface
{
    public interface IBlogManager
    {
        //Rizve
        Task<CommonResponse> CreateBlogManager(CreateBlogRequestEntity createBlogRequestEntity);
        //ask<CommonResponse> GetBlogManager();

        Task<CommonResponse?> GetByBlogIdManager(Guid id);


        Task<CommonResponse?> DeleteBlogManager(Guid id);



    }
}
