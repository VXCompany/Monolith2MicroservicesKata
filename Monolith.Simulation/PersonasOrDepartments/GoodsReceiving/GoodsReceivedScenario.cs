using Warehouse.Infra;

namespace Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;

public class GoodsReceivedScenario
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseRepository _warehouseRepository;

    public GoodsReceivedScenario(IUnitOfWork unitOfWork, IWarehouseRepository warehouseRepository)
    {
        _unitOfWork = unitOfWork;
        _warehouseRepository = warehouseRepository;
    }

    public async Task RunScenario()
    {
        // get a handle on how much is needed in pending orders..add 50
        var currentStock = await _warehouseRepository.GetAllAsync();

        var groups = currentStock.GroupBy(item => item.Name);
        
        
        await _unitOfWork.SaveChangesAsync();
    }
}