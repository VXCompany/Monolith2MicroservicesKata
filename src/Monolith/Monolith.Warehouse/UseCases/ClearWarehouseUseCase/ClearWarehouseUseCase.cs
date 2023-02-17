using Warehouse.Infra;

namespace Warehouse.UseCases.ClearWarehouseUseCase;

public class ClearWarehouseUseCase
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClearWarehouseUseCase(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task ClearWarehouseAsync()
    {
        var inventory = await _warehouseRepository.GetAllAsync();

        _warehouseRepository.DeleteRange(inventory);

        await _unitOfWork.SaveChangesAsync();
    }
}