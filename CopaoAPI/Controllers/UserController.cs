using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;

namespace CopaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginUser(LoginUserDTO loginUserDTO)
        {
            var result = await _userRepository.LoginUserAsync(loginUserDTO);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = await _userRepository.RegisterUserAsync(registerUserDTO);
            return Ok(result);
        }
    }
}
