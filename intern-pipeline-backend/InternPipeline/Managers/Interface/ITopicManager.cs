
using InternPipeline.Entities.RequestEntity;
using InternPipeline.Entities.ResponseEntity;

namespace InternPipeline.Managers.Interface
{
    public interface ITopicManager
    {
        Task<CommonResponse> CreateTopic(CreateTopicRequestEntity createTopicRequestEntity);
    }
}
