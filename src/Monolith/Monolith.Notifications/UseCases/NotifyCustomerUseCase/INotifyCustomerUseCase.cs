namespace Monolith.Notifications.UseCases.NotifyCustomerUseCase
{
    public interface INotifyCustomerUseCase
    {
        Task NotifyCustomer(NotifyCustomerRequest request);
    }
}