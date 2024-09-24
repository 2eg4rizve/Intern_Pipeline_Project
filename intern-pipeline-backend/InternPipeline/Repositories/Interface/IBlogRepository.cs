using InternPipeline.Models;

namespace InternPipeline.Repositories.Interface
{
    public interface IBlogRepository
    {
        Task<BlogModel> CreateBlogRepository(BlogModel blogModel);

        Task <List<BlogModel>> GetBlogRepository();

        Task<BlogModel?> GetByBlogIdRepository(Guid id);


        Task<BlogModel?> DeleteBlogRepository(Guid id);
    }
}
