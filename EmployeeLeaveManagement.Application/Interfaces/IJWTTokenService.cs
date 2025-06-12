using System;
using EmployeeLeaveManagement.Domain.Entities;

namespace EmployeeLeaveManagement.Application.Interfaces;

public interface IJWTTokenService
{
    string GenerateToken(User user);
}
