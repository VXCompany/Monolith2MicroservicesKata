using Warehouse.Infra;

namespace Monolith.ShoppingCart;

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
        
        return new Cart
        {
            CustomerNumber = cartData.CustomerNumber,
            Items = cartData
                        .Items
                        .Select(item => new CartItem
                        {
                            Id = item.Id,
                            Amount = item.Amount,
                            ProductId = item.ProductId
                        }).ToList()
        };
    }
}