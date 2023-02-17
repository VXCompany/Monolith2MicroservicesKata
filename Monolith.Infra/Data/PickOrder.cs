namespace Warehouse.Infra.Data;

public class PickOrder
{
    public Guid Id { get; set; }
    
    public Guid ForOrder { get; set; }
    
    public PickOrderStatus Status { get; set; }
    public ICollection<PickOrderLine> PickOrderLines { get; set; }
}