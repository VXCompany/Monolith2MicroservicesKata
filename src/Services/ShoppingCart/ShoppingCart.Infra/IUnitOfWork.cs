namespace ShoppingCart.Infra;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
