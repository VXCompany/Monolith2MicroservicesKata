namespace Notifications.Infra.Data;

public class Notification
{
    public Guid id { get; set; }
    public DateTime NotifiedAt { get; set; }
    public string CustomerNumber { get; set; }
    public string NotificationText { get; set; } = "";
    public string ApplicationSource { get; set; } = "NotificationsService";
}