using Microsoft.AspNetCore.Mvc;
using Warehouse;

namespace Monolith.API.Endpoints;

public static class Simulation
{
    public static void ConfigureSimulation(this WebApplication application)
    {
        var simulationGroup = application.MapGroup("simulation");
        simulationGroup.MapPatch("updatehourlywork", UpdateHourlyWork);
        simulationGroup.MapPatch("updatedailywork", UpdateDailyWork);
    }

    private static async Task<IResult> UpdateDailyWork(HttpContext context, [FromServices]UpdateQualityUseCase updateQualityUseCase)
    {
        await updateQualityUseCase.UpdateQuality();
        return Results.Ok();
    }

    private static IResult UpdateHourlyWork(HttpContext context, [FromServices]UpdateDailyWorkUseCase updateDailyWorkWarehouseUseCase)
    {
        // Handle pending orders in warehouse
        updateDailyWorkWarehouseUseCase.UpdateDailyWork();
        //

        return Results.Ok();
    }
}