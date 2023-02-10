public class Order
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; }
    public double TotalPrice { get; set; }
    public double TotalWithTax { get; set; }
    public OrderStatus Status { get; set; }
    
    public ICollection<OrderLine> OrderLines { get; set; }
}

public enum OrderStatus
{
    Processing,
    Shipped
}