using Monolith.ShoppingCart.Mappers;
using Warehouse.Infra;

namespace Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;

public class AddItemToShoppingCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly CartMapper _cartMapper;

    public AddItemToShoppingCartUseCase(IShoppingCartRepository shoppingCartRepository, CartMapper cartMapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _cartMapper = cartMapper;
    }

    public async Task AddItemToShoppingCartAsync(AddItemToShoppingCartRequest request)
    {
        var shoppingCartData = await _shoppingCartRepository.FindForCustomerAsync(request.CustomerNumber);

        Cart cart = _cartMapper.MapDataToDomain(shoppingCartData);

        cart.AddItemToCart(request.ProductId);

        _cartMapper.MapDomainToData(cart, shoppingCartData);

        await _shoppingCartRepository.Save(shoppingCartData);
    }
}