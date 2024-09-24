using InternPipeline.Models;

namespace InternPipeline.Repositories.Interface
{
    public interface IBlogRepository
    {
        Task<BlogModel> CreateBlogRepository(BlogModel blogModel);
    }
}
