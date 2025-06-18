using KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Sensor.Domain.Services;
using KeepItFresh.Platform.API.Sensor.Infrastructure.Persistance.EFC.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddControllers();

// HttpClient para InventoryGateway
builder.Services.AddHttpClient<InventoryHttpGateway>();

// DI explícita
builder.Services.AddScoped<IInventoryGateway, InventoryHttpGateway>();
builder.Services.AddScoped<SensorApplicationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();