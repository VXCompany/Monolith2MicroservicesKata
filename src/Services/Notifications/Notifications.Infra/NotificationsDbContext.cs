using Microsoft.EntityFrameworkCore;
using Notifications.Infra.Data;

namespace Notifications.Infra;

public class NotificationsDbContext : DbContext, IUnitOfWork
{
    public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<Notification>()
            .ToTable(nameof(Notification), "notification")
            .HasKey(n => n.id);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}