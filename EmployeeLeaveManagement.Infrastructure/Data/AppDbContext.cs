using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EmployeeLeaveManagement.Domain.Entities;

namespace EmployeeLeaveManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //Dbset of dbtables

    public DbSet<User> Users { get; set; }
}
