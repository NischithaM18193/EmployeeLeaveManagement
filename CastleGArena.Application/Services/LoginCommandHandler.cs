using System;
using EmployeeLeaveManagement.Application.Commands;
using EmployeeLeaveManagement.Application.DTOs;
using EmployeeLeaveManagement.Application.Interfaces;
using MediatR;

namespace EmployeeLeaveManagement.Application.Services;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDTO>
{
    private readonly IUserService _userService;
    private readonly IJWTTokenService _jwtTokenService;

    public LoginCommandHandler(IUserService userService, IJWTTokenService jWTTokenService)
    {
        _userService = userService;
        _jwtTokenService = jWTTokenService;
    }

    public async Task<AuthResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = _userService.Authenticate(request.UserName, request.PasswordHash);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var token = _jwtTokenService.GenerateToken(user);
              
        return new AuthResponseDTO { Token = token };
    }
}
