using Microsoft.AspNetCore.Mvc;
using Monolith.API.Integration;
using Monolith.ShoppingCart;
using Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;
using Monolith.ShoppingCart.UseCases.GetShoppingCartUseCase;
using Warehouse.Infra.Data;

namespace Monolith.API.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerNumber}", GetBasket);
        basketGroup.MapPost("/{customerNumber}", AddProduct);

        basketGroup.MapPost("/{customerId}/checkout", CheckoutBasket);
    }

    private static async Task<IResult> CheckoutBasket(HttpContext context, string customerNumber, CheckoutBasketService checkoutBasketService)
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
    
    
}