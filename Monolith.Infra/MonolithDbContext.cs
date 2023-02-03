using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class MonolithDbContext : DbContext
{
    public MonolithDbContext(DbContextOptions<MonolithDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<StockItem> Items => Set<StockItem>();
    public DbSet<Cart> Carts => Set<Cart>();

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
    }
}