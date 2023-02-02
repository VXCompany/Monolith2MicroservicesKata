using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Warehouse.UseCases.ReceiveGoodsUseCase;

public class ReceiveGoodsUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public ReceiveGoodsUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }
    
    public async Task ProcessReceivedGoodsAsync(ReceiveGoodsRequest receiveGoodsRequest)
    {
        foreach (var itemToStore in receiveGoodsRequest.ReceivedGoods)
        {
            var newStockedItem = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemToStore.Name,
                Quality = itemToStore.Quality,
                SellIn = itemToStore.SellIn,
                Count = itemToStore.AmountReceived
            };
            await _warehouseRepository.AddAsync(newStockedItem);
        }

        await _warehouseRepository.SaveChangesAsync();
    }
}