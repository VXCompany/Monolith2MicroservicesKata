namespace Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;

public record AddItemToShoppingCartRequest(string CustomerNumber, Guid ProductId);