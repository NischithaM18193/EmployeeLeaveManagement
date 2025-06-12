using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveManagement.Application.DTOs;
using EmployeeLeaveManagement.Application.Queries;

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
    }
}
