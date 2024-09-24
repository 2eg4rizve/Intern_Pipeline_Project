using InternPipeline.Models;
using InternPipeline.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace InternPipeline.Repositories.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly InternPipelineContext _dbContext;
        public TopicRepository(InternPipelineContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Topic> CreateTopic(Topic topic)
        {
            try
            {
                var topicInstance = await _dbContext.Topics.AddAsync(topic);
                await _dbContext.SaveChangesAsync();
                return topicInstance.Entity;
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return null;
        }

        public async Task<bool> IsTopicExist(string topicName)
        {
            try
            {
                return await _dbContext.Topics.AnyAsync(x => x.TopicName == topicName);
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return false;
        }
    }
}
