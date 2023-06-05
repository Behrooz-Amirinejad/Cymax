using Cymax.WebApp.Configurations;
using Cymax.WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Cymax.WebApp.DataContext;

public class ApplicationDbContext: IdentityDbContext<User>
{
    public DbSet<Employee> Employees { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // configurations
        builder.ApplyConfiguration(new RoleConfiguration());
    }
}
