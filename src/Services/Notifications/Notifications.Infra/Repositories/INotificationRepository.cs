using Notifications.Infra.Data;

namespace Warehouse.Infra;

public interface INotificationRepository
{
    Task Save(Notification notification);
}