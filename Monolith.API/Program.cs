using Microsoft.EntityFrameworkCore;
using Monolith.API.Endpoints;
using Monolith.API.Integration;
using Warehouse.Infra;

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

builder.Services.AddWarehouse();
builder.Services.AddShoppingCart();
builder.Services.AddOrderManagement();

builder.Services.AddTransient<CheckoutBasketService>();

builder.Services.AddInfra(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureBasketEndpoints();
app.ConfigureWarehouseEndpoints();
app.ConfigureSimulation();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MonolithDbContext>();
    db.Database.Migrate();
}

app.Run();