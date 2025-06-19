using KeepItFresh.Platform.API.Sensor.Domain.Services;

namespace KeepItFresh.Platform.API.Sensor.Domain.Model.Aggregates;

public class SensorAggregate
{
    public string Id { get; private set; }
    public string Type { get; private set; }
    public string Status { get; private set; }
    public int ProductId { get; private set; }

    private SensorAggregate() { }

    public SensorAggregate(string type, string status, ProductDto product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        if (DateTime.TryParse(product.ExpirationDate, out var expDate) && expDate < DateTime.UtcNow)
            throw new InvalidOperationException("Cannot assign sensor to expired product.");

        if (product.Sensor is not null)
            throw new InvalidOperationException("Product already has a sensor.");

        if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("Sensor type is required.");
        if (status != "active" && status != "inactive")
            throw new InvalidOperationException("Invalid sensor status.");

        Id = $"S-{product.Id}";
        Type = type;
        Status = status;
        ProductId = product.Id;
    }
}