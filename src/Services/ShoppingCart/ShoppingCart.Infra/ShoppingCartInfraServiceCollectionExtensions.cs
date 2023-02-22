using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Infra;
using ShoppingCart.Infra.HttpClients;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ShoppingCartInfraServiceCollectionExtensions
{
    public static void AddNotificationsServiceInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ShoppingCartDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("GildedRoseConnectionString");
            options.UseNpgsql(connectionString);
        });
    
        serviceCollection.AddScoped<IUnitOfWork>(sp => sp.GetService<ShoppingCartDbContext>());
        
        serviceCollection.AddHttpClient<NotificationServiceHttpClient>(client => 
            client.BaseAddress = new Uri(configuration["NotificationServiceUri"]));
    }
}