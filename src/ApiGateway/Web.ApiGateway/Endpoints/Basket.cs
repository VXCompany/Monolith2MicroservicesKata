using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.HttpClients;

namespace Web.ApiGateway.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerNumber}", GetBasket);
        basketGroup.MapPost("/{customerNumber}", AddProduct);
        basketGroup.MapPost("/{customerNumber}/checkout", CheckoutBasket);
    }

    private static async Task<IResult> GetBasket([FromServices]BasketHttpClientRouter basketHttpClientRouter, [FromHeader]bool? forceNewService, string customerNumber)
    {
        var getBasketResult = await basketHttpClientRouter.GetBasket(customerNumber, forceNewService == true);
        return Results.Ok(getBasketResult);
    }
    
    static async Task<IResult> AddProduct([FromServices]BasketHttpClientRouter basketHttpClientRouter, [FromHeader]bool? forceNewService, string customerNumber, string productCode)
    {
        basketHttpClientRouter.AddProduct(customerNumber, productCode, forceNewService == true);
        return Results.Ok();
    }

    private static async Task<IResult> CheckoutBasket([FromServices]BasketHttpClientRouter basketHttpClientRouter, [FromHeader]bool? forceNewService, string customerNumber)
    {
        await basketHttpClientRouter.CheckoutBasket(customerNumber, forceNewService == true);

        return Results.Ok();
    }
}