using System;
using EmployeeLeaveManagement.Application.DTOs;
using EmployeeLeaveManagement.Application.Queries;
using EmployeeLeaveManagement.Application.Interfaces;
using MediatR;
using System.Linq;

namespace EmployeeLeaveManagement.Application.Services;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
       var users = await _userService.GetAllUsersAsync();
       return users
           .Select(user => new UserDTO
           {
               UserID = user.UserID,
               UserName = user.UserName,
               Email = user.Email,
               Role = user.Role
           })
           .ToList();
    }
}
