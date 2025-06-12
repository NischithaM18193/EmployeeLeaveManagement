using System;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Infrastructure.Data;
using EmployeeLeaveManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeLeaveManagement.Domain.Entities;
using EmployeeLeaveManagement.Application.DTOs;
using System.Reflection.Metadata;
using EmployeeLeaveManagement.Application.Commands;

namespace EmployeeLeaveManagement.Infrastructure.Extensions;

public static class RegisterServiceCollection
{
    public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

// Add MediatR
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly); // if handler is elsewhere
                 cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly); // if handler is elsewhere
            });


        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJWTTokenService, JWTTokenService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        return services;
    }

}
