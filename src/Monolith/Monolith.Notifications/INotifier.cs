using Monolith.Notifications.UseCases.NotifyCustomerUseCase;

namespace Monolith.Notifications;

public interface INotifier
{
    Task NotifyCustomer(NotifyCustomerRequest request);
}