using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Monolith.ShoppingCart.UseCases.GetShoppingCartUseCase;

public class GetShoppingCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public GetShoppingCartUseCase(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }
    
    public async Task<Cart> GetShoppingCart(GetShoppingCartRequest request)
    {
        var cartData = await _shoppingCartRepository.FindForCustomerAsync(request.CustomerNumber);

        if (cartData == null)
        {
            return new Cart
            {
                CustomerNumber = request.CustomerNumber,
                Items = new List<CartItem>()
            };
        }

        return cartData;
    }
}