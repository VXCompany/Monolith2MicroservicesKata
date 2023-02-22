using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.HttpClients;

namespace Web.ApiGateway.Endpoints;

public static class Warehouse
{
    public static void ConfigureWarehouseEndpoints(this WebApplication application)
    {
        var warehouseGroup = application.MapGroup("warehouse");
        warehouseGroup.MapGet("", GetInventory);
        warehouseGroup.MapPost("receive-goods", ReceiveGoods);
    }

    private static async Task<IResult>  ReceiveGoods([FromServices]WarehouseHttpClientRouter warehouseHttpClientRouter, [FromHeader]bool? forceNewService, ReceiveGoodsRequest receiveGoodsRequest)
    {
        await warehouseHttpClientRouter.ReceiveGoods(receiveGoodsRequest, forceNewService == true);
        return Results.Ok();
    }

    private static async Task<IResult> GetInventory([FromServices]WarehouseHttpClientRouter warehouseHttpClientRouter, [FromHeader]bool? forceNewService)
    {
        var inventory = await warehouseHttpClientRouter.GetInventory(forceNewService == true);
        return Results.Ok(inventory);
    }
}