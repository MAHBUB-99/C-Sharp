using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


//[Frontend] → / start → fileId
//    ↓
//[Frontend] → / chunks(upload all chunks)
//    ↓
//[Backend] → merge chunks → /videos/{fileId}.mp4
//    ↓
//[Background Jobs] → generate thumbnails
//                  → transcode multiple resolutions
//                  → update Postgres metadata
//    ↓
//[Frontend] → fetch video details → show thumbnails + playable resolutions


namespace VideoStreamingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoUploadController : ControllerBase
    {
        [HttpPost("start")]
        public IActionResult StartUpload([FromBody] object request) => Ok();

        [HttpPost("{fileId}/chunks")]
        public IActionResult UploadChunk(string fileId, [FromForm] object request) => Ok();

        [HttpGet("{fileId}/status")]
        public IActionResult GetUploadStatus(string fileId) => Ok();

        [HttpPost("{fileId}/merge")]
        public IActionResult MergeChunks(string fileId, [FromBody] object request) => Ok();
    }
}
