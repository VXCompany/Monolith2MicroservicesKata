using Warehouse.Infra;

namespace Microsoft.Extensions.DependencyInjection.PersonasOrDepartments.OrderPicker;

public class ProcessNextOrderScenario
{
    private readonly IOrderRepository _orderRepository;

    public ProcessNextOrderScenario(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task ProcessNextOrder()
    {
        return Task.CompletedTask;
    }
}