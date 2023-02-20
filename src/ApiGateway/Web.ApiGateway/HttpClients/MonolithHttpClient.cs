namespace Web.ApiGateway.HttpClients;

public class MonolithHttpClient
{
    private readonly HttpClient _httpClient;

    public MonolithHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}