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

    private static async Task<IResult> GetBasket([FromServices]MonolithHttpClient monolithHttpClient, string customerNumber)
    {
        var getBasketResult = await monolithHttpClient.GetBasket(customerNumber);
        return Results.Ok(getBasketResult);
    }
    
    static async Task<IResult> AddProduct([FromServices]MonolithHttpClient monolithHttpClient, string customerNumber, string productCode)
    {
        monolithHttpClient.AddProduct(customerNumber, productCode);
        return Results.Ok();
    }

    private static async Task<IResult> CheckoutBasket([FromServices]MonolithHttpClient monolithHttpClient, string customerNumber)
    {
        await monolithHttpClient.CheckoutBasket(customerNumber);

        return Results.Ok();
    }
}