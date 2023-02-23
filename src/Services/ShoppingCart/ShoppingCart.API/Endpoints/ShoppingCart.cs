using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Responses;
using ShoppingCart.Infra;
using ShoppingCart.Infra.Data;
using CartItemResponse = ShoppingCart.API.Responses.CartItem;

namespace ShoppingCart.API.Endpoints;

public static class ShoppingCart
{
    public static void ConfigureShoppingCartEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        
        basketGroup.MapGet("/{customerNumber}", GetBasket);
        // basketGroup.MapPost("/{customerNumber}", AddProduct);
        //
        // basketGroup.MapPost("/{customerId}/checkout", CheckoutBasket);
    }

    private static async Task<GetBasketWebResponse> GetBasket(
        string customerNumber, 
        [FromServices] ShoppingCartDbContext db)
    {
        var shoppingCart = await db
            .Carts
            .Include(cart => cart.Items)
            .Where(cart => cart.CustomerNumber == customerNumber)
            .SingleOrDefaultAsync();

        var response = new GetBasketWebResponse()
        {
            CustomerNumber = customerNumber,
            Id = shoppingCart.Id,
            ApplicationSource = "to do",
            Items = shoppingCart.Items.Select(i => new CartItemResponse
            {
                Id = i.Id,
                ApplicationSource = i.ApplicationSource,
                Amount = i.Amount,
                ProductCode = i.ProductCode
            }).ToList()
        };
        
        return response;
    }
}
