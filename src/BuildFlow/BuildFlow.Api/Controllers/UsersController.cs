using BuildFlow.Api.Interfaces.Services;
using BuildFlow.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BuildFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var result = await _userService.GetProfileAsync(User.GetUserId());
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var result = await _userService.UpdateProfileAsync(User.GetUserId(), request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var result = await _userService.ChangePasswordAsync(User.GetUserId(), request);
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
