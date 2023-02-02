using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly WarehouseDbContext _dbContext;

    public WarehouseRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadOnlyCollection<Item> GetAll()
    {
        return _dbContext.Items.ToList().AsReadOnly();
    }

    public async Task AddAsync(Item item)
    {
        await _dbContext.Items.AddAsync(item);
    }

    public async Task UpdateRepositoryAsync()
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