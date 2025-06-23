namespace KeepItFresh.Platform.API.Sensor.Domain.Model.Commands;

public record UpdateSensorCommand(int ProductId, string Type, string Status);