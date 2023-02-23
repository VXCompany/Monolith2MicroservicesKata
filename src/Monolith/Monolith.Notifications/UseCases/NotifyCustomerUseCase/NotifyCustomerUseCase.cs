using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Monolith.Notifications.UseCases.NotifyCustomerUseCase;

public class NotifyCustomerUseCase : INotifier
{
    private readonly INotificationRepository _notificationRepository;

    public NotifyCustomerUseCase(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }
    
    public async Task NotifyCustomer(NotifyCustomerRequest request)
    {
        // some logic to determine best notification type depending on customer preferences..
        // ...

        await _notificationRepository.Save(new Notification
        {
            id = Guid.NewGuid(),
            NotifiedAt = DateTime.Now.ToUniversalTime(),
            NotificationText = request.NotificationText,
            CustomerNumber = request.CustomerNumber
        });
    }
}