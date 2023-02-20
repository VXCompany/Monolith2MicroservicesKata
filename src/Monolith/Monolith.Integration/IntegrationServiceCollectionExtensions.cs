using Monolith.Integration;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class IntegrationServiceCollectionExtensions
{
    public static void AddIntegration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CheckoutBasketService>();
    }
}