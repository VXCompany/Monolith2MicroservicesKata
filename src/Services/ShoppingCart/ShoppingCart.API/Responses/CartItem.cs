namespace ShoppingCart.API.Responses;

public class CartItem
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public string ProductCode { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}