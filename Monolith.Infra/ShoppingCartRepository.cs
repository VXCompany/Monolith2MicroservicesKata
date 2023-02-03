using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly MonolithDbContext _monolithDbContext;

    public ShoppingCartRepository(MonolithDbContext monolithDbContext)
    {
        _monolithDbContext = monolithDbContext;
    }
    
    public async Task<Cart?> FindForCustomerAsync(string customerNumber)
    {
        return await _monolithDbContext
            .Carts
            .Include(cart => cart.Items)
            .Where(cart => cart.CustomerNumber == customerNumber)
            .SingleOrDefaultAsync();
    }
}