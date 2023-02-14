using Warehouse.Infra;

namespace Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;

public class GoodsReceivedScenario
{
    private readonly IUnitOfWork _unitOfWork;

    public GoodsReceivedScenario(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task RunScenario()
    {
        await _unitOfWork.SaveChangesAsync();
    }
}