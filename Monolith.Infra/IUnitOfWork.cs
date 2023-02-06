namespace Warehouse.Infra;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}