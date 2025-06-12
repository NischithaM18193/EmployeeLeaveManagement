using System;
using System.Reflection.Metadata;
using EmployeeLeaveManagement.Domain.Entities;

namespace EmployeeLeaveManagement.Application.Interfaces;

public interface IUserService
{
    User? Authenticate(string UserName, string PasswordHash);
    Task AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetUserByEmailAsync(string Email);
}
