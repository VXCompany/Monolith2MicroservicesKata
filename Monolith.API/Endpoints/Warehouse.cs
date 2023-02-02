using Microsoft.AspNetCore.Mvc;
using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Monolith.API.Endpoints;

public static class Warehouse
{
    public static void ConfigureWarehouseEndpoints(this WebApplication application)
    {
        var warehouseGroup = application.MapGroup("warehouse");
        warehouseGroup.MapGet("", GetInventory);
        warehouseGroup.MapPost("receive-goods", ReceiveGoods);
    }

    private static Task ReceiveGoods()
    {
        throw new NotImplementedException();
    }

    static IEnumerable<Item> GetInventory(
        [FromServices]IWarehouseRepository warehouseRepository)
    {
        return warehouseRepository.GetAll();
    }
}