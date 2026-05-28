using System;
using MediatR;

namespace EmployeeLeaveManagement.Application.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid UserID { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
