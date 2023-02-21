using Web.ApiGateway.Endpoints;
using Web.ApiGateway.HttpClients;

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

builder.Services.AddHttpClient<MonolithHttpClient>(client => 
    client.BaseAddress = new Uri(config["MonolithServiceUri"]));

builder.Services.AddHttpClient<BasketServiceHttpClient>(client => 
    client.BaseAddress = new Uri(config["NotificationServiceUri"]));

builder.Services.AddHttpClient<BasketServiceHttpClient>(client => 
    client.BaseAddress = new Uri(config["BasketServiceUri"]));

builder.Services.AddTransient<BasketHttpClientRouter>();
builder.Services.AddTransient<WarehouseHttpClientRouter>();

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

app.MapControllers();

app.Run();