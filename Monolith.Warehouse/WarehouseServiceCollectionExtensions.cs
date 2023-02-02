using Warehouse;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WarehouseServiceCollectionExtensions
{
    public static void AddWarehouse(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<UpdateQualityUseCase>();
    }
}