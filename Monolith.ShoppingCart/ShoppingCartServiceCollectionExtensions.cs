using Monolith.ShoppingCart.Mappers;
using Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;
using Monolith.ShoppingCart.UseCases.CheckoutBasketUseCase;
using Monolith.ShoppingCart.UseCases.GetShoppingCartUseCase;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ShoppingCartServiceCollectionExtensions
{
    public static void AddShoppingCart(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<GetShoppingCartUseCase>();
        serviceCollection.AddTransient<AddItemToShoppingCartUseCase>();
        serviceCollection.AddTransient<CheckoutBasketUseCase>();

        serviceCollection.AddTransient<CartMapper>();
        serviceCollection.AddTransient<CartItemMapper>();
    }
}