using System;
using EmployeeLeaveManagement.Application.Commands;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using MediatR;

namespace EmployeeLeaveManagement.Application.Services;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand,bool>
{
    private readonly IUserService _userservice;
    public DeleteUserHandler(IUserService userservice)
    {
        _userservice = userservice;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "request cannot be null");
        }
       
        await _userservice.DeleteUserAsync(request.UserID);
        return true;
    }
}
