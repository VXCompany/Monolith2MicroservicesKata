using Microsoft.EntityFrameworkCore;

namespace Warehouse.Infra;

public class OrderRepository : IOrderRepository
{
    private readonly MonolithDbContext _monolithDbContext;

    public OrderRepository(MonolithDbContext monolithDbContext)
    {
        _monolithDbContext = monolithDbContext;
    }
    
    public async Task Save(Order order)
    {
        await _monolithDbContext.AddAsync(order);
    }

    public async Task<IReadOnlyCollection<Order>> GetAll()
    {
        return await _monolithDbContext.Orders.Include(o => o.OrderLines).ToListAsync();
    }
}