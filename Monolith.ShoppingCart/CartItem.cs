namespace Monolith.ShoppingCart;

public class CartItem
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid ProductId { get; set; }
}