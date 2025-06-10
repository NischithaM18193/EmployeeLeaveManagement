using System;

namespace EmployeeLeaveManagement.Domain.Entities;

public class User
{
    public Guid UserID { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; }

}
// This class represents a user in the Employee Leave Management system.