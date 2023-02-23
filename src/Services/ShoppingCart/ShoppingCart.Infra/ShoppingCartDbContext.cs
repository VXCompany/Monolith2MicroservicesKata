using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infra.Data;

namespace ShoppingCart.Infra;

public class ShoppingCartDbContext : DbContext, IUnitOfWork
{
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Cart> Carts => Set<Cart>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<Cart>()
            .ToTable(nameof(Cart), "shoppingcart")
            .HasKey(p => p.Id);
        modelBuilder
            .Entity<Cart>()
            .HasMany(c => c.Items)
            .WithOne(ci => ci.Cart);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}