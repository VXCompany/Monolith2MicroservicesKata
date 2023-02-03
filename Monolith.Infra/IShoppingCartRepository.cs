using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public interface IShoppingCartRepository
{
    Task<Cart?> FindForCustomerAsync(string customerNumber);
}