using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveManagement.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using EmployeeLeaveManagement.Application.Commands;

namespace EmployeeLeaveManagement.API.Controllers
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

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            return Ok(result);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterCommand registerCommand)
        {
            if (registerCommand == null)
            {
                return BadRequest("Invalid user data.");
            }
            var userId = _mediator.Send(registerCommand);
            return Ok(new { UserId = userId });
        }
    }
}
