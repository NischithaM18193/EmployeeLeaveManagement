using System;
using System.Diagnostics.CodeAnalysis;
using EmployeeLeaveManagement.Application.Commands;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using MediatR;

namespace EmployeeLeaveManagement.Application.Services;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserService _userservice;

    public UpdateUserHandler(IUserService userservice)
    {
        _userservice = userservice;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }
        var user = new User
        {
            UserID = request.UserID,
            UserName = request.UserName,
            Email = request.Email,
            Role = request.Role
        };
        var updateUser = _userservice.UpdateUserAsync(user);
        if (updateUser == null)
        {
            throw new InvalidOperationException("User update failed");
        }
        return true;
    }
}
