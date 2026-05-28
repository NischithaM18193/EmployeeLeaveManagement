using System;
using MediatR;
using EmployeeLeaveManagement.Application.Commands;
using EmployeeLeaveManagement.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using EmployeeLeaveManagement.Domain.Entities;


namespace EmployeeLeaveManagement.Application.Services;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public RegisterCommandHandler(IUserService userService, IPasswordHasher<User> passwordHasher)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserID = new Guid(),
            UserName = request.UserName,
            Email = request.Email,
            Role = request.Role
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.PasswordHash);

        await _userService.AddUserAsync(user);
        return user.UserID;
    }
}
