namespace Warehouse.Infra;

public interface IOrderRepository
{
    Task Save(Order order);
    Task<IReadOnlyCollection<Order>> GetAll();
    Task<IReadOnlyCollection<Order>> GetAllByStatus(params OrderStatus[] orderStatus);
}