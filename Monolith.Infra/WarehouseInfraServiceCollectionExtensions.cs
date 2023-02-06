using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Warehouse.Infra;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WarehouseInfraServiceCollectionExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<MonolithDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("GildedRoseConnectionString");
            options.UseNpgsql(connectionString);
        });

        serviceCollection.AddScoped<IUnitOfWork>(sp => sp.GetService<MonolithDbContext>());
        
        serviceCollection.AddTransient<IWarehouseRepository, WarehouseRepository>();
        serviceCollection.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();

        
        return serviceCollection;
    }
}