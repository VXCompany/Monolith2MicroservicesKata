using Warehouse.Infra;

namespace Warehouse.UseCases.ClearWarehouseUseCase;

public class ClearWarehouseUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public ClearWarehouseUseCase(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }
    
    public async Task ClearWarehouseAsync()
    {
        var inventory = await _warehouseRepository.GetAllAsync();

        _warehouseRepository.DeleteRange(inventory);

        await _warehouseRepository.SaveChangesAsync();
    }
}