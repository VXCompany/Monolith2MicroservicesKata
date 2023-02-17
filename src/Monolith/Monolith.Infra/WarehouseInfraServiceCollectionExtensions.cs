using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infra;
using Warehouse.Infra.BasketService;



public static class WarehouseInfraServceCollectionExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<MonolithDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("GildedRoseConnectionString");
            options.UseNpgsql(connectionString);
        });

        serviceCollection.Configure<BasketServiceConnectionOptions>(configuration.GetSection(BasketServiceConnectionOptions.BasketServiceConnection));

        serviceCollection.AddScoped<IUnitOfWork>(sp => sp.GetService<MonolithDbContext>());
        
        serviceCollection.AddTransient<IWarehouseRepository, WarehouseRepository>();
        serviceCollection.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
        serviceCollection.AddTransient<IOrderRepository, OrderRepository>();

        return serviceCollection;
    }
}