using Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;

namespace Monolith.Simulation.UseCases.UpdateDailyWorkUseCase;

public class UpdateDailyWorkUseCase
{
    private readonly GoodsReceivedScenario _goodsReceivedScenario;

    public UpdateDailyWorkUseCase(GoodsReceivedScenario goodsReceivedScenario)
    {
        _goodsReceivedScenario = goodsReceivedScenario;
    }
    
    public async Task UpdateDailyWork()
    {
        // Simulate receiving goods to replenish stocks
        await _goodsReceivedScenario.RunScenario();

        // Simulate 


        // Select Order in FIFO order


        // pick orders in FIFO order

        // Ship orders

        // Delay orders which can't be picked because of stock issues
    }
}