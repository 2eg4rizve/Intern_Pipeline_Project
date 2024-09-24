using InternPipeline.Models;

namespace InternPipeline.Repositories.Interface
{
    public interface IBlogRepository
    {
        Task<BlogModel> CreateBlogRepository(BlogModel blogModel);
        //sk <List<BlogModel>> GetBlogRepository();

        Task<BlogModel?> GetByBlogIdRepository(Guid id);
    }
}
