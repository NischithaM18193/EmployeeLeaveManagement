using System;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Infrastructure.Data;
using EmployeeLeaveManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeLeaveManagement.Infrastructure.Extensions;

public static class RegisterServiceCollection
{
    public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJWTTokenService, JWTTokenService>();

        return services;
    }

}
