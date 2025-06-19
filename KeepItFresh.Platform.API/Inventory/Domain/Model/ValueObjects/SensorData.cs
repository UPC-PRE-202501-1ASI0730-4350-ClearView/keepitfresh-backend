namespace KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

public class SensorData
{
    public string Id { get; private set; }
    public string Type { get; private set; }
    public string Status { get; private set; }

    public SensorData(string id, string type, string status)
    {
        Id = id;
        Type = type;
        Status = status;
    }
}