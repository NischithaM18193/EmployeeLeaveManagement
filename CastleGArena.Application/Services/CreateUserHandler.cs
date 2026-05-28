using System;
using EmployeeLeaveManagement.Application.Commands;
using EmployeeLeaveManagement.Application.DTOs;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using MediatR;

namespace EmployeeLeaveManagement.Application.Services;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserService _userService;
    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }

        var user = new User
        {
            UserID = new Guid(),
            UserName = request.UserName,
            Email = request.Email,
            Role = request.Role
        };

        var userID = await _userService.CreateUserAsync(user);
        return userID;
    }
    
}
