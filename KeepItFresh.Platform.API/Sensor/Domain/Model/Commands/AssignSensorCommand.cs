namespace KeepItFresh.Platform.API.Sensor.Domain.Model.Commands;

public record AssignSensorCommand(int ProductId, string Type, string Status);