using Warehouse.Core;
using Warehouse.Infra;

namespace Warehouse.UseCases.UpdateQualityUseCase;

public class UpdateQualityUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQualityUseCase(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }

    // used for simulation
    public async Task UpdateQuality()
    {
        var stock = await _warehouseRepository.GetAllAsync();

        var gildedRose = new GildedRose(stock.ToList());

        gildedRose.UpdateQuality();

        await _unitOfWork.SaveChangesAsync();
    }
}