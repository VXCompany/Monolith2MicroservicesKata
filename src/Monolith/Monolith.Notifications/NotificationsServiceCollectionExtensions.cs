using Monolith.Notifications;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class NotificationsServiceCollectionExtensions
{
    public static void AddNotifications(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<INotifier, ServiceNotifier>();
    }
}