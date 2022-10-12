using ECommerceAPI.Application.Features.Commands.AppUsers.GoogleLogin;
using ECommerceAPI.Application.Features.Commands.AppUsers.LoginUser;
using ECommerceAPI.Application.Features.Commands.AppUsers.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromForm]RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }
    }
}
