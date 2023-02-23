using Notifications.Infra;
using Notifications.Infra.Data;

namespace Warehouse.Infra;

public class NotificationRepository : INotificationRepository
{
    private readonly NotificationsDbContext _notificationsDbContext;

    public NotificationRepository(NotificationsDbContext monolithDbContext)
    {
        _notificationsDbContext = monolithDbContext;
    }

    public async Task Save(Notification notification)
    {
        await _notificationsDbContext.AddAsync(notification);
    }
}