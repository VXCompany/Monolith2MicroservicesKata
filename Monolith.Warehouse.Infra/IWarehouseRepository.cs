using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public interface IWarehouseRepository
{
    Task<IReadOnlyCollection<Item>> GetAllAsync();
    Task AddAsync(Item item);

    Task SaveChangesAsync();

    void DeleteRange(IEnumerable<Item> items);
}