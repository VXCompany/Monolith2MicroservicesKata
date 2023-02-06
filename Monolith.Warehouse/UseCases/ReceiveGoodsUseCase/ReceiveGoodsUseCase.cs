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
                Name = itemToStore.Name,
                Quality = itemToStore.Quality,
                SellIn = itemToStore.SellIn,
                Count = itemToStore.AmountReceived
            };
            await _warehouseRepository.AddAsync(newStockedItem);
        }

        await _unitOfWork.SaveChangesAsync();
    }
}