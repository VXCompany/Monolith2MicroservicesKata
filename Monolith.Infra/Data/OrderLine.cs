public class OrderLine
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string Name { get; set; }
    public int TotalOrdered { get; set; }
    public Order Order { get; set; }
}