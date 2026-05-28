using System;
using EmployeeLeaveManagement.Application.Interfaces;
using EmployeeLeaveManagement.Domain.Entities;
using EmployeeLeaveManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Infrastructure.Repositories;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? Authenticate(string username, string password)
    {
        return _dbContext.Users.AsNoTracking()
        .FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);
    }

    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<Guid> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user.UserID;
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        }
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}
