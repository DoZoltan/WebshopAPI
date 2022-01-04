using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationBLL _AuthenticationBLL;

        public AuthenticationController(IAuthenticationBLL AuthenticationBLL)
        {
            _AuthenticationBLL = AuthenticationBLL;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestDTO userDTO)
        {
            var registrationResult = await _AuthenticationBLL.Registration(userDTO);

            if (registrationResult.Succeeded)
            {
                await _AuthenticationBLL.LoginAtRegistration(registrationResult.User);

                return Ok(registrationResult.Messages);
            }

            return BadRequest(registrationResult.Messages);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginDTO)
        {
            var searchUserResult = await _AuthenticationBLL.GetUserByEmail(loginDTO.Email);

            if (!searchUserResult.Succeeded)
            {
                return BadRequest("wrong credentials");
            }

            var loginResult = await _AuthenticationBLL.Login(loginDTO, searchUserResult.User);

            if (loginResult.Succeeded)
            {
                return Ok(loginResult.Messages);
            }

            return BadRequest("wrong credentials");
        }

        [Authorize]
        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _AuthenticationBLL.Logout();

            return Ok("Logged out");
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO requestDTO)
        {
            var searchUserResult = await _AuthenticationBLL.GetCurrentUserByClaimsPrincipal(HttpContext.User);

            if (!searchUserResult.Succeeded)
            {
                return BadRequest(searchUserResult.Messages);
            }

            var changeResult = await _AuthenticationBLL.ChangePassword(requestDTO, searchUserResult.User);

            if (changeResult.Succeeded)
            {
                return Ok(changeResult.Messages);
            }

            return BadRequest(changeResult.Messages);
        }

        [Authorize]
        [HttpGet("TestAuthorization")]
        public IActionResult TestAuthorization()
        {
            return Ok("You can enter here only after login");
        }
    }
}
