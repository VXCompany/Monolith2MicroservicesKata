using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notifications.Infra;
using Warehouse.Infra;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class NotificationsInfraServiceCollectionExtensions
{
    public static void AddNotificationsServiceInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<NotificationsDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("GildedRoseConnectionString");
            options.UseNpgsql(connectionString);
        });

        serviceCollection.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<NotificationsDbContext>());
        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
    }
}