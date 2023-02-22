using System.Text.Json;

namespace Web.ApiGateway.HttpClients;

public record ReceiveGoodsRequest(IEnumerable<ReceivedGood> ReceivedGoods);

public record ReceivedGood(string ProductCode, int Quality, int SellIn, int AmountReceived);

public class WarehouseHttpClientRouter
{
    private readonly MonolithHttpClient _monolithHttpClient;

    public WarehouseHttpClientRouter(MonolithHttpClient monolithHttpClient)
    {
        _monolithHttpClient = monolithHttpClient;
    }
    
    public async Task<JsonDocument> GetInventory(bool forceNewService)
    {
        return await _monolithHttpClient.GetInventory();
    }

    public async Task ReceiveGoods(ReceiveGoodsRequest receiveGoodsRequest, bool forceNewService)
    {
        await _monolithHttpClient.ReceiveGoods(receiveGoodsRequest);
    }
}