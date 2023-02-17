namespace ShoppingCart.API.Endpoints;

public static class ShoppingCart
{
    public static void ConfigureShoppingCartEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        
        // TODO: Add necesarry endpoints
        /*basketGroup.MapGet("/{customerNumber}", GetBasket);
        basketGroup.MapPost("/{customerNumber}", AddProduct);

        basketGroup.MapPost("/{customerId}/checkout", CheckoutBasket);
        */
    }
}