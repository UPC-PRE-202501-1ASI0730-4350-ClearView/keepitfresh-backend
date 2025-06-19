namespace KeepItFresh.Platform.API.Inventory.Interfaces.REST.Resources;

public class ProductResource
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? Image { get; set; }
    public SensorResource? Sensor { get; set; }
}

public class SensorResource
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Status { get; set; } = null!;
}