using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveManagement.Application.DTOs;
using EmployeeLeaveManagement.Application.Queries;
using EmployeeLeaveManagement.Application.Commands;

namespace EmployeeLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            if (createUserCommand == null)
            {
                return BadRequest("CreateUserCommand cannot be null");
            }

            var userId = await _mediator.Send(createUserCommand);
            return Ok(userId);

        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            if (updateUserCommand == null)
            {
                return BadRequest("UpdateUserCommand cannot be null");
            }

            var result = await _mediator.Send(updateUserCommand);
            return Ok(result);
        }
        [HttpDelete("DeleteUser/{userId}")]
        public async Task<ActionResult<bool>> DeleteUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("User ID cannot be empty");
            }

            var result = await _mediator.Send(new DeleteUserCommand { UserID = userId });
            return Ok(result);
        }
    }
}
