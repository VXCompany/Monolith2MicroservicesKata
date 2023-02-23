using System.Text;
using System.Text.Json;
using Warehouse.Infra;

namespace Monolith.Notifications.UseCases.NotifyCustomerUseCase;

public class NotifyCustomerUseCase : INotifyCustomerUseCase
{
    private readonly INotificationRepository _notificationRepository;

    public NotifyCustomerUseCase()
    {
    }

    public async Task NotifyCustomer(NotifyCustomerRequest request)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5200");
        var httpRequest = new HttpRequestMessage
        {
            RequestUri = new Uri("/notifycustomer", UriKind.Relative),
            Method = HttpMethod.Post,
            Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8,
                                    "application/json")
        };

        var response = await httpClient.SendAsync(httpRequest);
        response.EnsureSuccessStatusCode();
    }
}