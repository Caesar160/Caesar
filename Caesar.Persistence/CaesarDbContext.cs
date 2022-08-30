namespace Caesar.Persistence;

using System.Reflection;
using Application.Interfaces;
using Caesar.Persistence.Extensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CaesarDbContext : DbContext, ICaesarDbContext
{
    public CaesarDbContext(DbContextOptions<CaesarDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users
    {
        get;
        set;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastUpdatedAt = DateTime.UtcNow;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Seed();
        base.OnModelCreating(builder);
    }

}
