namespace Warehouse.Infra.Data;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
    public int Count { get; set; }
}