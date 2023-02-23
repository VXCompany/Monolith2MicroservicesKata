namespace Notifications.API.UseCases;

public record NotifyCustomerRequest(string CustomerNumber, string NotificationText);