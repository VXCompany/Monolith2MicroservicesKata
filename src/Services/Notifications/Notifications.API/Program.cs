using Microsoft.AspNetCore.Mvc;
using Notifications.Infra;
using Notifications.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNotificationsServiceInfra(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapControllers();

app.MapPost("/notification", async ([FromBody] NotificationRequest request, [FromServices] NotificationsDbContext db) =>
{
    await db.AddAsync(new Notification
    {
        id = Guid.NewGuid(),
        NotifiedAt = DateTime.Now.ToUniversalTime(),
        NotificationText = request.NotificationText,
        CustomerNumber = request.CustomerNumber
    });

    await db.SaveChangesAsync();
    
    return Results.Ok();
});

app.Run();

public record NotificationRequest(string NotificationText, string CustomerNumber);