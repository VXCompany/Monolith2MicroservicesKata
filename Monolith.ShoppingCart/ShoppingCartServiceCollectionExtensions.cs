using Monolith.ShoppingCart;
// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ShoppingCartServiceCollectionExtensions
{
    public static void AddShoppingCart(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<GetShoppingCartUseCase>();
    }
}