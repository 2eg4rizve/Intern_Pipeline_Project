
using InternPipeline.Entities.RequestEntity;
using InternPipeline.Entities.ResponseEntity;
using InternPipeline.Managers.Interface;
using InternPipeline.Models;
using InternPipeline.Repositories.Interface;

namespace InternPipeline.Managers.Manager
{
    public class TopicManager : ITopicManager
    {
        private readonly ITopicRepository _topicRepository;
        public TopicManager(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<CommonResponse> CreateTopic(CreateTopicRequestEntity createTopicRequestEntity)
        {
            var commonResponse = new CommonResponse();
            try
            {
                // check if the topic is exist
                var isTopicExist = await _topicRepository.IsTopicExist(createTopicRequestEntity.topic_name);
                if (isTopicExist)
                {
                    // logger
                    commonResponse.status_code = 422;
                    commonResponse.message = "Topic already exist";
                    return commonResponse;
                }
                // create new topic
                var createTopic = await _topicRepository.CreateTopic(new Topic
                {
                    TopicName = createTopicRequestEntity.topic_name,
                    SubjectId = createTopicRequestEntity.subject_id
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
