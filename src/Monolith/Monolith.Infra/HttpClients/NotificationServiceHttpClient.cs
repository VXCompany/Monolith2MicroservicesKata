using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Warehouse.Infra.HttpClients;

public class NotificationServiceHttpClient
{
    private readonly HttpClient _httpClient;

    public NotificationServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendNotification(Notification request)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(request, new JsonSerializerOptions(JsonSerializerDefaults.Web)), 
            new MediaTypeHeaderValue("application/json"));
        
        await _httpClient.PostAsync("notification", content);
    }
}

public record Notification(string CustomerNumber, string NotificationText);