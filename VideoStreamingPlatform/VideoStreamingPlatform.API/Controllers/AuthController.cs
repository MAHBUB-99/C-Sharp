using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] object request) => Ok();

        [HttpPost("login")]
        public IActionResult Login([FromBody] object request) => Ok();

        [HttpPost("logout")]
        public IActionResult Logout() => Ok();

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] object request) => Ok();

        [HttpGet("profile")]
        public IActionResult GetProfile() => Ok();

        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] object request) => Ok();

        [HttpPut("change-password")]
        public IActionResult ChangePassword([FromBody] object request) => Ok();

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] object request) => Ok();

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] object request) => Ok();
    }
}
