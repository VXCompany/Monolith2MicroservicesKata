using Monolith.Simulation.PersonasOrDepartments.GoodsReceiving;
using Monolith.Simulation.UseCases.UpdateDailyWorkUseCase;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class SimulationServiceCollectionExtensions
{
    public static void AddSimulation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<GoodsReceivedScenario>();
        serviceCollection.AddTransient<UpdateDailyWorkUseCase>();
    }
}