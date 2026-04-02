namespace Infrastructure.Persistence;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditAndSoftDelete()
    {
        var utcNow = DateTime.UtcNow;

        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not IDatabaseEntity entity)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = utcNow;
                    break;

                case EntityState.Modified:
                    entity.UpdatedAt = utcNow;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entity.IsDeleted = true;
                    entity.DeletedAt = utcNow;
                    break;
            }
        }
    }
}
