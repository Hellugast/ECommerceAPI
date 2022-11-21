using ECommerceAPI.Application.CustomAttributes;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.AppUsers.AssignRoleToUser;
using ECommerceAPI.Application.Features.Commands.AppUsers.CreateUser;
using ECommerceAPI.Application.Features.Commands.AppUsers.GoogleLogin;
using ECommerceAPI.Application.Features.Commands.AppUsers.LoginUser;
using ECommerceAPI.Application.Features.Commands.AppUsers.UpdatePassword;
using ECommerceAPI.Application.Features.Queries.AppUser.GetAllUsers;
using ECommerceAPI.Application.Features.Queries.AppUser.GetUserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse result = await _mediator.Send(createUserCommandRequest);
            return Ok(result);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-user-roles/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get User Roles", Menu = "Users")]
        public async Task<IActionResult> GetUserRoles([FromRoute] GetUserRolesQueryRequest getUserRolesQueryRequest)
        {
            GetUserRolesQueryResponse response = await _mediator.Send(getUserRolesQueryRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role to User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }

    }
}
