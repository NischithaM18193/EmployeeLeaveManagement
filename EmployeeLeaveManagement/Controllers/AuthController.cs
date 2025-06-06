using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userservice;
        private readonly IJWTTokenService _jwttokenservice;

        public AuthController(IUserService userservice, IJWTTokenService jwttokenservice)
        {
            _userservice = userservice;
            _jwttokenservice = jwttokenservice;
        }

        public IActionResult Login([FromBody] User login)
        {
            var user = _userservice.Authenticate(login.UserName, login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid Credentials");
            }

            var token = _jwttokenservice.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
