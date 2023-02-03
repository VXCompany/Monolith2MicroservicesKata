using Microsoft.EntityFrameworkCore;
using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly WarehouseDbContext _dbContext;

    public WarehouseRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public async Task AddAsync(Item item)
    {
        await _dbContext.Items.AddAsync(item);
    }

    public void DeleteRange(IEnumerable<Item> items)
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
    private readonly WarehouseDbContext _warehouseDbContext;

    public WarehousePersister(WarehouseDbContext warehouseDbContext)
    {
        _warehouseDbContext = warehouseDbContext;
    }

    public void PersistChanges()
    {
        _warehouseDbContext.SaveChanges();
    }
}