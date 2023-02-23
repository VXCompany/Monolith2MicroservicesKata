using Monolith.Notifications.UseCases.NotifyCustomerUseCase;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class NotificationsServiceCollectionExtensions
{
    public static void AddNotifications(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<INotifyCustomerUseCase, NotifyCustomerUseCase>();
    }
}