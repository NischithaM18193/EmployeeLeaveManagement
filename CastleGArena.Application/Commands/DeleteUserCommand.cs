using System;
using MediatR;

namespace EmployeeLeaveManagement.Application.Commands;

public class DeleteUserCommand :IRequest<bool>
{
    public Guid UserID { get; set; }
}
