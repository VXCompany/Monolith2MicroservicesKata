using Microsoft.AspNetCore.Mvc;
using Monolith.OrderManagement;
using Monolith.ShoppingCart;
using Warehouse.Infra;

namespace Monolith.API.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerNumber}", GetBasket);
        basketGroup.MapPost("/{customerId}", AddProduct);

        basketGroup.MapPost("/{customerId}/checkout", CheckoutBasket);
    }

    private static IResult CheckoutBasket(HttpContext context, CreateOrderUseCase createOrderUseCase)
    {
        // redirect
        // skip all kinds of payments complexity...for this kata, assume that payment is done and successful....basket is cleared..order is created
        
        // CreateOrderCommand => handle it in OrderManagement
        createOrderUseCase.CreateOrder();

        return Results.Ok();
    }

    static async Task<Cart> GetBasket([FromServices]GetShoppingCartUseCase getShoppingCartUse, string customerNumber)
    {
        return await getShoppingCartUse.GetShoppingCart(new GetShoppingCartRequest(customerNumber));
    }
    
    static void AddProduct(string customerId, string productId)
    {
        // Add product to basket
    }
    
    
}