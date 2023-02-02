using Monolith.OrderManagement;
using Monolith.ShoppingCart;

namespace Monolith.API.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerId}", GetBasket);
        basketGroup.MapPost("/{customerId}", AddProduct);

        basketGroup.MapPost("/{customerId}/checkout", CheckoutBasket);
    }

    private static IResult CheckoutBasket(HttpContext context, CreateOrderUseCase createOrderUseCase)
    {
        // redirect
        // skip all kinds of payments complexity...for this kata, assume that payment is done and successful....basket is cleared..order is created
        
        // CreateOrderCommand => handle it in Ordermanagement
        createOrderUseCase.CreateOrder();

        return Results.Ok();
    }

    static IEnumerable<Cart> GetBasket(string customerId)
    {
        return null;
    }
    
    static void AddProduct(string customerId, string productId)
    {
        // Add product to basket
    }
    
    
}