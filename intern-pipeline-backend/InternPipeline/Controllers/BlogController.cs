using InternPipeline.Entities.RequestEntity;
using InternPipeline.Managers.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InternPipeline.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //hello
        private readonly IBlogManager _blogManager;

        public BlogController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        [HttpPost("create-blog")]
        public async Task<IActionResult> CreateBlog(CreateBlogRequestEntity createBlogRequestEntity)
        {
            var response = await _blogManager.CreateBlog(createBlogRequestEntity);
            return Ok(response);
        }
    }
}
