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

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

public interface IWarehousePersister
{
    void PersistChanges();
}

public class WarehousePersister : IWarehousePersister
{
    private readonly MonolithDbContext _monolithDbContext;

    public WarehousePersister(MonolithDbContext monolithDbContext)
    {
        _monolithDbContext = monolithDbContext;
    }

    public void PersistChanges()
    {
        _monolithDbContext.SaveChanges();
    }
}