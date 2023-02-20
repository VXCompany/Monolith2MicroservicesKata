using Microsoft.AspNetCore.Mvc;
using Web.ApiGateway.HttpClients;

namespace Web.ApiGateway.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerNumber}", GetBasket);
//        basketGroup.MapPost("/{customerNumber}", AddProduct);

//        basketGroup.MapPost("/{customerNumber}/checkout", CheckoutBasket);
    }

    private static Task GetBasket([FromServices]MonolithHttpClient monolithHttpClient, string customerNumber)
    {
        throw new NotImplementedException();
    }

    /*
    private static async Task<IResult> CheckoutBasket(string customerNumber, CheckoutBasketService checkoutBasketService)
    {
        await checkoutBasketService.CheckoutBasket(customerNumber);

        return Results.Ok();
    }

    static async Task<Cart> GetBasket([FromServices]GetShoppingCartUseCase getShoppingCartUse, string customerNumber)
    {
        return await getShoppingCartUse.GetShoppingCart(new GetShoppingCartRequest(customerNumber));
    }
    
    static async Task<IResult> AddProduct([FromServices]AddItemToShoppingCartUseCase addItemToShoppingCartUseCase, string customerNumber, string productCode)
    {
        await addItemToShoppingCartUseCase.AddItemToShoppingCartAsync(
            new AddItemToShoppingCartRequest(customerNumber, productCode));
        return Results.Ok();
    }
    */
    
    
}