using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Inventory.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Inventory.Interfaces.REST.Transform;

public class ProductResourceAssembler
{
    public static ProductDto ToResource(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Quantity = product.Quantity,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
            ExpirationDate = product.ExpirationDate.ToString("yyyy-MM-dd"),
            Image = product.Image,
            Sensor = product.Sensor is null
                ? null
                : new SensorDto
                {
                    Id = product.Sensor.Id,
                    Type = product.Sensor.Type,
                    Status = product.Sensor.Status
                }
        };
    }
    
    public static SensorData? ToSensorEntity(SensorDto? dto)
    {
        return dto is null
            ? null
            : new SensorData(dto.Id, dto.Type, dto.Status);
    }
}