using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;
using Lapka.Notification.Core.Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Notification.Infrastructure.DataBase;

public class DataContext : DbContext
{
    public DbSet<UserData> UserData { get; set; }
    public DbSet<Core.Domain.Entities.NotificationHistory> NotificationHistory { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("notification");
        builder.ApplyConfigurationsFromAssembly(typeof(NotificationHistoryConfiguration).Assembly);

        base.OnModelCreating(builder);
    }

    #region ICreatedAt SaveChanges update

    private void UpdateTimestamps()
    {
        foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Added))
        {
            if (entity.Entity is ICreatedAt created)
            {
                created.CreatedAt = DateTime.UtcNow;
            }
        }

        foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Modified))
        {
            if (entity.Entity is IModifiedAt updated)
            {
                updated.ModifiedAt = DateTime.UtcNow;
            }
        }
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    #endregion
}