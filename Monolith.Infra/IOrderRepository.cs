namespace Warehouse.Infra;

public interface IOrderRepository
{
    Task Save(Order order);
    Task<IReadOnlyCollection<Order>> GetAll();
}