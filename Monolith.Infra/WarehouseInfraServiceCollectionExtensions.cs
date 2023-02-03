using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Warehouse.Infra;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WarehouseInfraServiceCollectionExtensions
{
    public static IServiceCollection AddWarehouseInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<WarehouseDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("GildedRoseConnectionString");
            options.UseNpgsql(connectionString);
        });

        serviceCollection.AddTransient<IWarehouseRepository, WarehouseRepository>();
        
        return serviceCollection;
    }
}