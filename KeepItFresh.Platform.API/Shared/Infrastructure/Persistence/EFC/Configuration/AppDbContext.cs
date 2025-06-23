using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
    
    public DbSet<Orders> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        
        builder.Entity<Orders>()
            .HasKey(o => o.Id);  
        
        base.OnModelCreating(builder);

        

        builder.UseSnakeCaseNamingConvention();
    }
}