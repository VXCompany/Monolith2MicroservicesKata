namespace Notifications.Infra;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}