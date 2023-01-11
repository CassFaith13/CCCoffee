using CCCoffee.Models.Token;
using CCCoffee.Models.User;
using CCCoffee.Services.Token;
using CCCoffee.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCCoffee.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("Register User")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registerResult = await _userService.RegisterUserAsync(model);

            if (registerResult)
            {
                return Ok("New user successfully registered");
            }
            return BadRequest("New user could NOT be created. Please try again.");
        }
        [HttpPost, Route("~/api/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tokenResponse = await _tokenService.GetTokenAsync(request);

            if (tokenResponse is null)
            {
                return BadRequest("Invalid username or password.");
            }
            return Ok(tokenResponse);
        }
        [Authorize]
        [HttpGet, Route("{userId")]
        public async Task<IActionResult> GetById(int userId)
        {
            var userDetail = await _userService.GetUserByIdAsync(userId);
            if (userDetail is null)
            {
                return NotFound();
            }
            return Ok(userDetail);
        }
    }
}