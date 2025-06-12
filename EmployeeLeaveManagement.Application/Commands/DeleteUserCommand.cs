using System;
using MediatR;

namespace EmployeeLeaveManagement.Application.Commands;

public class DeleteUserCommand :IRequest
{
    public Guid UserID { get; set; }
}
