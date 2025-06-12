using System;
using MediatR;
using EmployeeLeaveManagement.Application.DTOs;

namespace EmployeeLeaveManagement.Application.Queries;

public class GetAllUsersQuery : IRequest<List<UserDTO>>
{

}
