using Notifications.Infra.Data;
using Warehouse.Infra;

namespace Notifications.API.UseCases;

public class NotifyCustomerUseCase
{
    private readonly INotificationRepository _notificationRepository;

    public NotifyCustomerUseCase(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task NotifyCustomerAsync(NotifyCustomerRequest request)
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