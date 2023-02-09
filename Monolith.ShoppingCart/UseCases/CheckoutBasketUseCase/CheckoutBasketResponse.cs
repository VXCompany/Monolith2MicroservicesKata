using Warehouse.Infra.Data;

namespace Monolith.ShoppingCart.UseCases.CheckoutBasketUseCase;

public record CheckoutBasketResponse(Cart CheckedOutCart);