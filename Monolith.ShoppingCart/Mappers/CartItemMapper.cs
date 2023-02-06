namespace Monolith.ShoppingCart.Mappers;

public class CartItemMapper
{
    public CartItem MapFromData(Warehouse.Infra.Data.CartItem item)
    {
        return new CartItem
        {
            Id = item.Id,
            Amount = item.Amount,
            ProductId = item.ProductId
        };
    }

    public void MapDomainToData(CartItem item, Warehouse.Infra.Data.CartItem cartItem)
    {
        cartItem.Amount = item.Amount;
        cartItem.ProductId = item.ProductId;
    }
}