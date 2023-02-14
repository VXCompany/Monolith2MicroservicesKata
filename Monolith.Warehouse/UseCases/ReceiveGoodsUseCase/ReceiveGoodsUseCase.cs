using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Warehouse.UseCases.ReceiveGoodsUseCase;

public class ReceiveGoodsUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReceiveGoodsUseCase(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task ProcessReceivedGoodsAsync(ReceiveGoodsRequest receiveGoodsRequest)
    {
        foreach (var itemToStore in receiveGoodsRequest.ReceivedGoods)
        {
            var newStockedItem = new StockItem
            {
                Id = Guid.NewGuid(),
                ProductCode = itemToStore.ProductCode,
                Name = GetProductNameFromProductCode(itemToStore.ProductCode),
                Quality = itemToStore.Quality,
                SellIn = itemToStore.SellIn,
                Count = itemToStore.AmountReceived
            };
            await _warehouseRepository.AddAsync(newStockedItem);
        }
        await _unitOfWork.SaveChangesAsync();
    }

    private string GetProductNameFromProductCode(string productCode)
    {
        return productCode switch
        {
            "NORM-MoonJ" => "Moonberry Juice",
            "EPIC-Ragnaros" => "Sulfuras, Hand of Ragnaros",
            "TICK-TAFK" => "Backstage passes to a TAFKAL80ETC concert",
            "SPOIL-BRIE" => "Aged Brie",
            _ => throw new InvalidOperationException("unknown product")
        };
    }
}