using System.Text.Json;

namespace Web.ApiGateway.HttpClients;

public class MonolithHttpClient
{
    private readonly HttpClient _httpClient;

    public MonolithHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // basket or shoppingcart endpoints
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
    
    // Warehouse endpoints
    public async Task<JsonDocument> GetInventory()
    {
        var responseMessage = await _httpClient.GetAsync($"warehouse");

        return await responseMessage.Content.ReadFromJsonAsync<JsonDocument>();
    }

    public async Task ReceiveGoods(ReceiveGoodsRequest receiveGoodsRequest)
    {
        var requestUri = $"warehouse/receiveGoods";
        await _httpClient.PostAsync(requestUri, new StringContent(JsonSerializer.Serialize(receiveGoodsRequest)));
    }

    // Simulation endpoints
    public async Task DayHasPassed()
    {
        var requestUri = $"simulation/dayhaspassed";

        await _httpClient.PatchAsync(requestUri, null);
    }

    public async Task UpdateHourlyWork()
    {
        var requestUri = $"simulation/updatehourlywork";

        await _httpClient.PatchAsync(requestUri, null);
    }

    public async Task ResetSimulation()
    {
        var requestUri = $"simulation/resetsimulation";

        await _httpClient.PatchAsync(requestUri, null);
    }
}