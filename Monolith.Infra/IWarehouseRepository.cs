using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public interface IWarehouseRepository
{
    Task<IReadOnlyCollection<StockItem>> GetAllAsync();
    Task AddAsync(StockItem stockItem);
    void DeleteRange(IEnumerable<StockItem> items);
}