using Warehouse.UseCases.ReceiveGoodsUseCase;
using Warehouse.UseCases.UpdateQualityUseCase;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WarehouseServiceCollectionExtensions
{
    public static void AddWarehouse(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ReceiveGoodsUseCase>();
        serviceCollection.AddTransient<UpdateQualityUseCase>();
    }
}