using Warehouse.Infra;

namespace Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;

public class GoodsReceivedScenario
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;

    public GoodsReceivedScenario(IUnitOfWork unitOfWork, IWarehouseRepository warehouseRepository, IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
    }

    public async Task RunScenario()
    {
        var currentStock = await _warehouseRepository.GetAllAsync();
        var allOrders = await _orderRepository.GetAll();

        var groups = currentStock.GroupBy(item => item.Name);

        allOrders.SelectMany(o => o.OrderLines).GroupBy(ol => ol.ProductCode);
        
        await _unitOfWork.SaveChangesAsync();
    }
}