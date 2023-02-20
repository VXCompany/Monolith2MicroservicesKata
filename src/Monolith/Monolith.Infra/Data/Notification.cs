namespace Warehouse.Infra.Data;

public class Notification
{
    public Guid id { get; set; }
    public DateTime NotifiedAt { get; set; }
    public string NotificationText { get; set; } = "";
    public string ApplicationSource { get; set; } = "Monolith";
}