namespace Monolith.ShoppingCart;

public class Cart
{
    public string CustomerNumber { get; set; }
    public ICollection<CartItem> Items { get; set; }
}

public class CartItem
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid ProductId { get; set; }
}