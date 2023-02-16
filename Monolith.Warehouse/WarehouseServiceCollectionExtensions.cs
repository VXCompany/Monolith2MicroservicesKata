using Microsoft.Extensions.DependencyInjection.UseCases.PickOrderUseCase;
using Warehouse.UseCases.ClearWarehouseUseCase;
using Warehouse.UseCases.ReceiveGoodsUseCase;
using Warehouse.UseCases.UpdateQualityUseCase;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WarehouseServiceCollectionExtensions
{
    public static void AddWarehouse(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<PickOrderUseCase>();
        serviceCollection.AddTransient<ReceiveGoodsUseCase>();
        serviceCollection.AddTransient<UpdateQualityUseCase>();
        serviceCollection.AddTransient<ClearWarehouseUseCase>();
    }
}