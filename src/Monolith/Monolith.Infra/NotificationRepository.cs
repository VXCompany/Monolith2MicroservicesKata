using Warehouse.Infra.Data;

namespace Warehouse.Infra;

public class NotificationRepository : INotificationRepository
{
    private readonly MonolithDbContext _monolithDbContext;

    public NotificationRepository(MonolithDbContext monolithDbContext)
    {
        _monolithDbContext = monolithDbContext;
    }
    
    public async Task Save(Notification notification)
    {
        await _monolithDbContext.AddAsync(notification);
    }
}