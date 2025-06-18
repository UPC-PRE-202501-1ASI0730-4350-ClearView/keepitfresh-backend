using KeepItFresh.Platform.API.Sensor.Domain.Services;
using KeepItFresh.Platform.API.Sensor.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Sensor.Interfaces.REST.Transform;

public static class SensorResourceAssembler
{
    public static SensorResource ToResource(ProductDto.SensorData sensor) => new()
    {
        Type = sensor.Type,
        Status = sensor.Status
    };
}