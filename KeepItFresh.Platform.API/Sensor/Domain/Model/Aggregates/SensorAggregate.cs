namespace KeepItFresh.Platform.API.Sensor.Domain.Model.Aggregates;

public class SensorAggregate
{
    public string Id { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int ProductId { get; set; }
}