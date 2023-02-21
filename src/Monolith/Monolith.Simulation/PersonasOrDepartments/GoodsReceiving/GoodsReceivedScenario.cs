using Monolith.Integration;
using Warehouse.Infra;
using Warehouse.UseCases.ReceiveGoodsUseCase;

namespace Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;

public class GoodsReceivedScenario
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly GoodsReceivedService _goodsReceivedService;
    private readonly ReceiveGoodsUseCase _receiveGoodsUseCase;

    public GoodsReceivedScenario(IWarehouseRepository warehouseRepository, IOrderRepository orderRepository, GoodsReceivedService goodsReceivedService)
    {
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
        _goodsReceivedService = goodsReceivedService;
    }

    public async Task RunScenario()
    {
        var receiveGoodsList = new List<ReceivedGood?>();
        receiveGoodsList.Add(await RestockProduct("NORM-MoonJ", 20, 50));
        receiveGoodsList.Add(await RestockProduct("EPIC-Ragnaros", 80, 1));
        receiveGoodsList.Add(await RestockProduct("TICK-TAFK", 20, 10));
        receiveGoodsList.Add(await RestockProduct("SPOIL-BRIE", 25, 20));
        //

        receiveGoodsList = receiveGoodsList.Where(record => record != null).ToList();
        if (receiveGoodsList.Count > 0)
        {
            await _goodsReceivedService.GoodsReceived(new ReceiveGoodsRequest(receiveGoodsList!));
        }
    }

    private async Task<ReceivedGood?> RestockProduct(string productCode, int quality, int topOffAtNewStockCount)
    {
        var currentStock = await _warehouseRepository.GetAllAsync();
        var productCodeCurrentlyInStock = currentStock.Where(stock => stock.ProductCode == productCode).Sum(stock => stock.Count);
        
        var allOrders = await _orderRepository.GetAllByStatus(OrderStatus.Processing);
        var productCodeCurrentlyOrdered = allOrders.SelectMany(o => o.OrderLines).Where(ol => ol.ProductCode == productCode).Sum(ol => ol.TotalOrdered);
        
        var diff = productCodeCurrentlyInStock - productCodeCurrentlyOrdered;
        var min = Math.Min(diff, 0);
        if (min < topOffAtNewStockCount)
        {
            return new ReceivedGood(productCode, quality, quality, topOffAtNewStockCount - min);
        }
        
        return null;
    }
}