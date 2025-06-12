using System;
using EmployeeLeaveManagement.Application.DTOs;
using MediatR;

namespace EmployeeLeaveManagement.Application.Commands;

public class LoginCommand :IRequest<AuthResponseDTO>
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
