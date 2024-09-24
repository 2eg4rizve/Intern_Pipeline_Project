
using InternPipeline.Entities.RequestEntity;
using InternPipeline.Entities.ResponseEntity;
using InternPipeline.Managers.Interface;
using InternPipeline.Models;
using InternPipeline.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace InternPipeline.Managers.Manager
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
       
        public async Task<CommonResponse> CreateBlogManager(CreateBlogRequestEntity createBlogRequestEntity )
        {
            var commonResponse = new CommonResponse();
            try
            {

                var createBlog = await _blogRepository.CreateBlogRepository(new BlogModel
                {
                    Title = createBlogRequestEntity.Title,
                    Text = createBlogRequestEntity.Text,
                    BlogImage = createBlogRequestEntity.BlogImage,

                });
                if (createBlog == null)
                {
                    // logger
                    commonResponse.status_code = 422;
                    commonResponse.message = "Failed to create topic";
                    return commonResponse;
                }
                commonResponse.status_code = 200;
                commonResponse.message = "Success";
                commonResponse.data = createBlog;
                return commonResponse;

            }
            catch (Exception ex)
            {
                // add logger ex
                commonResponse.status_code = 500;
            }
            return commonResponse;
        }

        public async Task<CommonResponse?> GetByBlogIdManager(Guid id)
        {
            var commonResponse = new CommonResponse();
            try
            {

                var GetBlogById = await _blogRepository.GetByBlogIdRepository(id);


                if (GetBlogById == null)
                {
                    // logger
                    commonResponse.status_code = 422;
                    commonResponse.message = "No Blog Found";
                    return commonResponse;
                }
                commonResponse.status_code = 200;
                commonResponse.message = "Success";
                commonResponse.data = GetBlogById;
                return commonResponse;

            }
            catch (Exception ex)
            {
                // add logger ex
                commonResponse.status_code = 500;
            }
            return commonResponse;
        }

       

        //public async Task<CommonResponse> GetBlogManager()
        //{
        //    var commonResponse = new CommonResponse();
        //    try
        //    {

        //        var createTopic = await _blogRepository.GetBlogRepository();
        //        if (createTopic == null)
        //        {
        //            // logger
        //            commonResponse.status_code = 422;
        //            commonResponse.message = "Failed to create topic";
        //            return commonResponse;
        //        }
        //        commonResponse.status_code = 200;
        //        commonResponse.message = "Success";
        //        return commonResponse;

        //    }
        //    catch (Exception ex)
        //    {
        //        // add logger ex
        //        commonResponse.status_code = 500;
        //    }
        //    return commonResponse;
        //}
    }
}
