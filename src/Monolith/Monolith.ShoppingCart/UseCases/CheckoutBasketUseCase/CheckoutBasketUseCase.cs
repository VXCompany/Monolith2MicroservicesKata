using Warehouse.Infra;

namespace Monolith.ShoppingCart.UseCases.CheckoutBasketUseCase;

public class CheckoutBasketUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public CheckoutBasketUseCase(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }
    
    public async Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request)
    {
        var shoppingCart = await _shoppingCartRepository.FindForCustomerAsync(request.CustomerNumber);

        if (shoppingCart == null || shoppingCart.Items.Count == 0)
        {
            throw new InvalidOperationException($"Unable to checkout basket, customer currently doesn't have one");
        }
        
        _shoppingCartRepository.Delete(shoppingCart);

        return new CheckoutBasketResponse(shoppingCart);
    }
}