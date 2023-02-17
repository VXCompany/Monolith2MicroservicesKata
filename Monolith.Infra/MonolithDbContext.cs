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
    public DbSet<PickOrder> PickOrders => Set<PickOrder>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<StockItem>()
            .ToTable(nameof(StockItem), "warehouse")
            .HasKey(i => i.Id);
        modelBuilder.Entity<PickOrder>()
            .ToTable(nameof(PickOrder), "warehouse")
            .HasKey(pi => pi.Id);
        modelBuilder.Entity<PickOrder>()
            .HasMany(pi => pi.PickOrderLines)
            .WithOne(pil => pil.PickOrder);
        modelBuilder
            .Entity<PickOrderLine>()
            .HasKey(pil => pil.Id);

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