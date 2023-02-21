using System.Text.Json;

namespace Web.ApiGateway.HttpClients;

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