using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.HttpClients;

namespace Web.ApiGateway.Endpoints;

public static class Simulation
{
    public static void ConfigureSimulation(this WebApplication application)
    {
        var simulationGroup = application.MapGroup("simulation");
        simulationGroup.MapPatch("updatehourlywork", UpdateHourlyWork);
        simulationGroup.MapPatch("dayhaspassed", DayHasPassed);
        simulationGroup.MapPatch("resetsimulation", ResetSimulation);
    }

    private static async Task<IResult> DayHasPassed([FromServices]MonolithHttpClient monolithHttpClient)
    {
        await monolithHttpClient.DayHasPassed();
        return Results.Ok();
    }

    private static async Task<IResult> UpdateHourlyWork([FromServices]MonolithHttpClient monolithHttpClient)
    {
        // Handle pending orders in warehouse
        await monolithHttpClient.UpdateHourlyWork();
        return Results.Ok();
    }

    private static async Task<IResult> ResetSimulation([FromServices]MonolithHttpClient monolithHttpClient)
    {
        await monolithHttpClient.ResetSimulation();
        return Results.Ok();
    }
}