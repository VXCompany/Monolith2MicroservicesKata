using Microsoft.AspNetCore.Mvc;
using Monolith.API.WebResponses;
using Monolith.Integration;
using Monolith.OrderManagement.UseCases.CreateOrderUseCase;
using Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;
using Monolith.ShoppingCart.UseCases.GetShoppingCartUseCase;
using Warehouse.Infra.Data;
using CartItem = Monolith.API.WebResponses.CartItem;

namespace Monolith.API.Endpoints;

public static class Basket
{
    public static void ConfigureBasketEndpoints(this WebApplication application)
    {
        var basketGroup = application.MapGroup("Basket");
        basketGroup.MapGet("/{customerNumber}", GetBasket);
        basketGroup.MapPost("/{customerNumber}", AddProduct);

        basketGroup.MapPost("/{customerNumber}/checkout", CheckoutBasket);

        basketGroup.MapPost("/{customerNumber}/order", CreateOrder);
    }

    private static async Task<IResult> CreateOrder(
        [FromBody] Cart cart,
        [FromServices] CreateOrderUseCase useCase)
    {
        var request = new CreateOrderRequest(cart);
        await useCase.CreateOrder(request);
        
        return Results.Ok();
    }

    private static async Task<IResult> CheckoutBasket(string customerNumber, CheckoutBasketService checkoutBasketService)
    {
        await checkoutBasketService.CheckoutBasket(customerNumber);

        return Results.Ok();
    }

    static async Task<GetBasketWebResponse> GetBasket([FromServices]GetShoppingCartUseCase getShoppingCartUse, string customerNumber)
    {
        var cartData = await getShoppingCartUse.GetShoppingCart(new GetShoppingCartRequest(customerNumber));
        return new GetBasketWebResponse
        {
            Id = cartData.Id,
            ApplicationSource = cartData.ApplicationSource,
            CustomerNumber = cartData.CustomerNumber,
            Items = cartData.Items.Select(item => new CartItem
            {
                Id = item.Id,
                ApplicationSource = item.ApplicationSource,
                ProductCode = item.ProductCode,
                Amount = item.Amount
            }).ToList()
        };
    }
    
    static async Task<IResult> AddProduct([FromServices]AddItemToShoppingCartUseCase addItemToShoppingCartUseCase, string customerNumber, string productCode)
    {
        await addItemToShoppingCartUseCase.AddItemToShoppingCartAsync(
            new AddItemToShoppingCartRequest(customerNumber, productCode));
        return Results.Ok();
    }
    
    
}