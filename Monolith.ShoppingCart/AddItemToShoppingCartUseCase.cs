using Warehouse.Infra;

namespace Monolith.ShoppingCart;

public class AddItemToShoppingCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public AddItemToShoppingCartUseCase(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task AddItemToShoppingCartAsync(AddItemToShoppingCartRequest request)
    {
        throw new NotImplementedException();
    }
}