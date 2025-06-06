using System;
using System.Reflection.Metadata;
using EmployeeLeaveManagement.Domain.Entities;

namespace EmployeeLeaveManagement.Application.Interfaces;

public interface IUserService
{
    User? Authenticate(string UserName, string Password);
}
