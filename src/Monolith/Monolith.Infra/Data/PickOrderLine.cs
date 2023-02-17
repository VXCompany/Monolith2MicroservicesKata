namespace Warehouse.Infra.Data;

public class PickOrderLine
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
    public int Amount { get; set; }
    public PickOrder PickOrder { get; set; }
}