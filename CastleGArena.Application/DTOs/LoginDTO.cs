using System;

namespace EmployeeLeaveManagement.Application.DTOs;

public class LoginDTO
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
