using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Sensor.Infrastructure.Persistence.EFC;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().OwnsOne(p => p.Sensor);
    }
}
