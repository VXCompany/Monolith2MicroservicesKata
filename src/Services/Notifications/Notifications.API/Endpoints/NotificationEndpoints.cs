using Microsoft.AspNetCore.Mvc;
using Notifications.API.UseCases;

namespace Notifications.API.Endpoints;

public static class NotificationEndpoints
{
    public static void ConfigureNotificationEndpoints(this WebApplication application)
    {
        application.MapPost("/{notifycustomer}", NotifyCustomer);
    }

    private static async Task<IResult> NotifyCustomer(
        [FromServices] NotifyCustomerUseCase notifyCustomerUseCase,
        [FromBody] NotifyCustomerRequest notifyCustomerRequest)
    {
        await notifyCustomerUseCase.NotifyCustomerAsync(notifyCustomerRequest);

        return Results.Ok();
    }
}