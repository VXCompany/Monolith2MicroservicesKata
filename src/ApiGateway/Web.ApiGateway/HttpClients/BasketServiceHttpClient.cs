using System.Text.Json;

namespace Web.ApiGateway.HttpClients;

public class BasketServiceHttpClient
{
    private readonly HttpClient _httpClient;

    public BasketServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<JsonDocument> GetBasket(string customerNumber)
    {
        var responseMessage = await _httpClient.GetAsync($"basket/{customerNumber}");

        return await responseMessage.Content.ReadFromJsonAsync<JsonDocument>();
    }
    
    public async Task AddProduct(string customerNumber, string productCode)
    {
        var requestUri = $"basket/{customerNumber}?productCode={productCode}";
        await _httpClient.PostAsync(requestUri, null);
    }

    public async Task CheckoutBasket(string customerNumber)
    {
        var requestUri = $"basket/{customerNumber}/checkout";
        await _httpClient.PostAsync(requestUri, null);
    }
}