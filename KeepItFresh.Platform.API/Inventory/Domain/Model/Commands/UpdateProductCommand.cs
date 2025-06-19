using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;

public record UpdateProductCommand( int Id,
    string Name,
    string Category,
    int Quantity,
    decimal Price,
    DateTime ExpirationDate,
    string? Image,
    SensorData? Sensor);