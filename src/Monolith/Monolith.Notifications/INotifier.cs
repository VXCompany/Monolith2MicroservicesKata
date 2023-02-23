using Monolith.Notifications.UseCases.NotifyCustomerUseCase;
using Warehouse.Infra.HttpClients;

namespace Monolith.Notifications;

public interface INotifier
{
    Task NotifyCustomer(NotifyCustomerRequest request);
}

public class ServiceNotifier : INotifier
{
    private readonly NotificationServiceHttpClient _http;

    public ServiceNotifier(NotificationServiceHttpClient http)
    {
        _http = http;
    }

    public async Task NotifyCustomer(NotifyCustomerRequest notifyCustomerRequest)
    {
        var request = new Notification(notifyCustomerRequest.CustomerNumber, notifyCustomerRequest.NotificationText);
        
        await _http.SendNotification(request);
    }
}