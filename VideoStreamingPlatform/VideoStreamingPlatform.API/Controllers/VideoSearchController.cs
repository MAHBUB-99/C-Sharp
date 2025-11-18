using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoSearchController : ControllerBase
    {
        // Search by title, description, tags, filename
        [HttpGet]
        public IActionResult SearchVideos([FromQuery] string query)
        {
            return Ok();
        }
    }
}
