using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public interface IWarehouseRepository
{
    IReadOnlyCollection<Item> GetAll();
    Task AddAsync(Item item);

    Task UpdateRepositoryAsync();
}