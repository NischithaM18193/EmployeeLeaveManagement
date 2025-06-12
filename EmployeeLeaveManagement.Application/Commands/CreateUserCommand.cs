using System;
using MediatR;

namespace EmployeeLeaveManagement.Application.Commands;

public class CreateUserCommand : IRequest<Guid>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
