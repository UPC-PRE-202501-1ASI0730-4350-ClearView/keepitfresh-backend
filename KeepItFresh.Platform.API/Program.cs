using KeepItFresh.Platform.API.Inventory.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Inventory.Application.Internal.QueryServices;
using KeepItFresh.Platform.API.Inventory.Domain.Repositories;
using KeepItFresh.Platform.API.Inventory.Infrastructure.Persistence.EFC;
using KeepItFresh.Platform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;
using KeepItFresh.Platform.API.Sensor.Application.Internal.QueryServices;
using KeepItFresh.Platform.API.Sensor.Domain.Services;
using KeepItFresh.Platform.API.Sensor.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
        policy.WithOrigins("http://localhost:5176") 
            .AllowAnyHeader()
            .AllowAnyMethod());
});


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInventoryGateway, InventoryHttpGateway>();
builder.Services.AddScoped<SensorApplicationService>();
builder.Services.AddHttpClient<InventoryHttpGateway>();
builder.Services.AddScoped<ProductCommandService>();
builder.Services.AddScoped<ProductQueryService>();
builder.Services.AddScoped<SensorCommandService>();
builder.Services.AddScoped<SensorQueryService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowVueApp");
app.MapControllers();
app.Run();