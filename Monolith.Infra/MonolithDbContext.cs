using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class MonolithDbContext : DbContext, IUnitOfWork
{
    public MonolithDbContext(DbContextOptions<MonolithDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<StockItem> Items => Set<StockItem>();
    public DbSet<Cart> Carts => Set<Cart>();

    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<StockItem>()
            .ToTable(nameof(StockItem), "warehouse")
            .HasKey(i => i.Id);

        modelBuilder
            .Entity<Cart>()
            .ToTable(nameof(Cart), "shoppingcart")
            .HasKey(p => p.Id);
        modelBuilder
            .Entity<Cart>()
            .HasMany(c => c.Items)
            .WithOne(ci => ci.Cart);

        modelBuilder
            .Entity<Order>()
            .ToTable(nameof(Order), "ordering")
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderLines)
            .WithOne(ol => ol.Order);

        modelBuilder
            .Entity<OrderLine>()
            .HasKey(ol => ol.Id);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}