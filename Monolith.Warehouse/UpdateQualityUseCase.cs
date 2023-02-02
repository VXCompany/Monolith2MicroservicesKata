using Warehouse.Infra;

namespace Warehouse;

public class UpdateQualityUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public UpdateQualityUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    // used for simulation
    public async Task UpdateQuality()
    {
        var stock = _warehouseRepository.GetAll();

        var gildedRose = new GildedRose(stock.ToList());

        gildedRose.UpdateQuality();

        await _warehouseRepository.UpdateRepositoryAsync();
    }
}