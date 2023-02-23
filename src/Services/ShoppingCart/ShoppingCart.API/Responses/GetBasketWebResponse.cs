namespace ShoppingCart.API.Responses;

public class GetBasketWebResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; }
    public ICollection<CartItem> Items { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}