using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly MonolithDbContext _dbContext;

    public WarehouseRepository(MonolithDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<StockItem>> GetAllAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public async Task AddAsync(StockItem stockItem)
    {
        await _dbContext.Items.AddAsync(stockItem);
    }

    public void DeleteRange(IEnumerable<StockItem> items)
    {
        _dbContext.Items.RemoveRange(items);
    }
}