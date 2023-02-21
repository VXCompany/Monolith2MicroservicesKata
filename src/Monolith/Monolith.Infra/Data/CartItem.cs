namespace Warehouse.Infra.Data;

public class CartItem
{
    public Guid Id { get; set; }
    public Cart Cart { get; set; }
    public int Amount { get; set; }
    public string ProductCode { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}