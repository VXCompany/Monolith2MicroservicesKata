using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class MonolithDbContext : DbContext
{
    public MonolithDbContext(DbContextOptions<MonolithDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Cart> Carts => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Item>()
            .ToTable(nameof(Item), "warehouse")
            .HasKey(i => i.Id);

        modelBuilder
            .Entity<Cart>()
            .ToTable(nameof(Cart), "shoppingcart")
            .HasKey(i => i.Id);
    }
}