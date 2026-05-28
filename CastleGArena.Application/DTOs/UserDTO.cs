using System;

namespace EmployeeLeaveManagement.Application.DTOs;

public class UserDTO
{
    public Guid UserID { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string?  Role { get; set; }
}
