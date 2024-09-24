using InternPipeline.Models;

namespace InternPipeline.Repositories.Interface
{
    public interface ITopicRepository
    {
        Task<bool> IsTopicExist (string topicName);
        Task<Topic> CreateTopic (Topic topic);
    }
}
