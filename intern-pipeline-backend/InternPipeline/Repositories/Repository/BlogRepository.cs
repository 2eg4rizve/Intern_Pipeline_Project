using InternPipeline.Models;
using InternPipeline.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace InternPipeline.Repositories.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly InternPipelineContext _dbContext;

        public BlogRepository(InternPipelineContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public async Task<BlogModel> CreateBlogRepository(BlogModel blogModel)
        {
            try
            {
                var blogInstance = await _dbContext.BlogTable.AddAsync(blogModel);
                await _dbContext.SaveChangesAsync();
                return blogInstance.Entity;
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return null;
        }

        
        public async Task<BlogModel?> GetByBlogIdRepository(Guid id)
        {
            try
            {
                var blogInstanc = await _dbContext.BlogTable.FirstOrDefaultAsync(x => x.Id == id);

              

                return blogInstanc;
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return null;
        }


        public async Task<BlogModel?> DeleteBlogRepository(Guid id)
        {
            try
            {
                var blogInstanc = await _dbContext.BlogTable.FirstOrDefaultAsync(x => x.Id == id);


                _dbContext.BlogTable.Remove(blogInstanc);
                await _dbContext.SaveChangesAsync();
                return blogInstanc;

                return blogInstanc;
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return null;
        }


        //public async Task<List<BlogModel>> GetBlogRepository()
        //{

        //    var profilesDomain = await profileRepository.GetAllAsync();

        //}
    }
}
