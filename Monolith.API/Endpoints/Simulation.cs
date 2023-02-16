using Microsoft.AspNetCore.Mvc;
using Monolith.Simulation.UseCases.UpdateDailyWorkUseCase;
using Warehouse.UseCases.ClearWarehouseUseCase;
using Warehouse.UseCases.UpdateQualityUseCase;

namespace Monolith.API.Endpoints;

public static class Simulation
{
    public static void ConfigureSimulation(this WebApplication application)
    {
        var simulationGroup = application.MapGroup("simulation");
        simulationGroup.MapPatch("updatehourlywork", UpdateHourlyWork);
        simulationGroup.MapPatch("dayhaspassed", DayHasPassed);
        simulationGroup.MapPatch("resetsimulation", ResetSimulation);
    }

    private static async Task<IResult> DayHasPassed(HttpContext context, [FromServices]UpdateQualityUseCase updateQualityUseCase)
    {
        await updateQualityUseCase.UpdateQuality();
        return Results.Ok();
    }

    private static async Task<IResult> UpdateHourlyWork(HttpContext context, [FromServices]UpdateDailyWorkUseCase updateDailyWorkWarehouseUseCase)
    {
        // Handle pending orders in warehouse
        await updateDailyWorkWarehouseUseCase.UpdateDailyWork();
        return Results.Ok();
    }

    private static async Task<IResult> ResetSimulation(HttpContext context, [FromServices]ClearWarehouseUseCase clearWarehouseUseCase)
    {
        await clearWarehouseUseCase.ClearWarehouseAsync();
        return Results.Ok();
    }
}