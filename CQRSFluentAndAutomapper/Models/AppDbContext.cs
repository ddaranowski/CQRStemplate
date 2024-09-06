using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CQRSFluentAndAutomapper.Models;

public class AppDbContext : DbContext
{
    public DbSet<Flow> Flows { get; set; }
    public DbSet<Channel> Channels { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}