using System.Text.Json;

namespace Web.ApiGateway.HttpClients;

public class MonolithHttpClient
{
    private readonly HttpClient _httpClient;

    public MonolithHttpClient(HttpClient httpClient)
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

public class BasketHttpClientRouter
{
    private readonly MonolithHttpClient _monolithHttpClient;
    private readonly BasketServiceHttpClient _basketServiceHttpClient;

    public BasketHttpClientRouter(MonolithHttpClient monolithHttpClient, BasketServiceHttpClient basketServiceHttpClient)
    {
        _monolithHttpClient = monolithHttpClient;
        _basketServiceHttpClient = basketServiceHttpClient;
    }
    
    public async Task<JsonDocument> GetBasket(string customerNumber, bool forceNewService)
    {
        if (forceNewService)
        {
            return await _basketServiceHttpClient.GetBasket(customerNumber);
        }
        return await _monolithHttpClient.GetBasket(customerNumber);
    }

    public async Task AddProduct(string customerNumber, string productCode, bool forceNewService)
    {
        if (forceNewService)
        {
            await _basketServiceHttpClient.AddProduct(customerNumber, productCode);
            return;
        }
        await _monolithHttpClient.AddProduct(customerNumber, productCode);
    }

    public async Task CheckoutBasket(string customerNumber, bool forceNewService)
    {
        if (forceNewService)
        {
            await _basketServiceHttpClient.CheckoutBasket(customerNumber);
            return;
        }
        await _monolithHttpClient.CheckoutBasket(customerNumber);
    }
}