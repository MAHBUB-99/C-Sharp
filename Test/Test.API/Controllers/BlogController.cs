using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Services;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Domain.Entities.Blog blog)
        {
            var createdBlog = await _blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }   

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Domain.Entities.Blog blog)
        {
            var result = await _blogService.UpdateAsync(id, blog);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _blogService.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
