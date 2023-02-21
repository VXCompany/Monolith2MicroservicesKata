namespace Monolith.API.WebResponses;

public class GetBasketWebResponse
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; }
    public ICollection<CartItem> Items { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}

public class CartItem
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public string ProductCode { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}