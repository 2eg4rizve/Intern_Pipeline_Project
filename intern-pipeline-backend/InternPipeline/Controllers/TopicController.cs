using InternPipeline.Entities.RequestEntity;
using InternPipeline.Managers.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InternPipeline.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicManager _topicManager;

        public TopicController(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        [HttpPost("create-topic")]
        public async Task<IActionResult> CreateTopic(CreateTopicRequestEntity createTopicRequestEntity)
        {
            var response = await _topicManager.CreateTopic(createTopicRequestEntity);
            return Ok(response);
        }
    }
}
