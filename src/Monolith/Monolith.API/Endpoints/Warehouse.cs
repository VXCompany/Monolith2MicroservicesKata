using Microsoft.AspNetCore.Mvc;
using Warehouse.Infra;
using Warehouse.Infra.Data;
using Warehouse.UseCases.ReceiveGoodsUseCase;

namespace Monolith.API.Endpoints;

public static class Warehouse
{
    public static void ConfigureWarehouseEndpoints(this WebApplication application)
    {
        var warehouseGroup = application.MapGroup("warehouse");
        warehouseGroup.MapGet("", GetInventory);
        warehouseGroup.MapPost("receive-goods", ReceiveGoods);
    }

    private async static Task<IResult>  ReceiveGoods([FromServices]ReceiveGoodsUseCase receiveGoodsUseCase, ReceiveGoodsRequest receiveGoodsRequest)
    {
        await receiveGoodsUseCase.ProcessReceivedGoodsAsync(receiveGoodsRequest);
        return Results.Ok();
    }

    static async Task<IEnumerable<StockItem>> GetInventory(
        [FromServices]IWarehouseRepository warehouseRepository)
    {
        return await warehouseRepository.GetAllAsync();
    }
}