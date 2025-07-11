using System;
using MediatR;

namespace EmployeeLeaveManagement.Application.DTOs;

public class RegisterDTO 
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
