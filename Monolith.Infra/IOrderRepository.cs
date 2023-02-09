namespace Warehouse.Infra;

public interface IOrderRepository
{
    Task Save(Order order);
}