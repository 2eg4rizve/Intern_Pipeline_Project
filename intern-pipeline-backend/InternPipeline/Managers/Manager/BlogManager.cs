
using InternPipeline.Entities.RequestEntity;
using InternPipeline.Entities.ResponseEntity;
using InternPipeline.Managers.Interface;
using InternPipeline.Models;
using InternPipeline.Repositories.Interface;


namespace InternPipeline.Managers.Manager
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
       
        public async Task<CommonResponse> CreateBlogManager(CreateBlogRequestEntity createBlogRequestEntity)
        {
            var commonResponse = new CommonResponse();
            try
            {


                var createTopic = await _blogRepository.CreateBlogRepository(new BlogModel
                {
                    Title = createBlogRequestEntity.Title,
                    Text = createBlogRequestEntity.Text,
                    BlogImage = createBlogRequestEntity.BlogImage,



                });
                if (createTopic == null)
                {
                    // logger
                    commonResponse.status_code = 422;
                    commonResponse.message = "Failed to create topic";
                    return commonResponse;
                }
                commonResponse.status_code = 200;
                commonResponse.message = "Success";
                return commonResponse;

            }
            catch (Exception ex)
            {
                // add logger ex
                commonResponse.status_code = 500;
            }
            return commonResponse;
        }
    }
}
