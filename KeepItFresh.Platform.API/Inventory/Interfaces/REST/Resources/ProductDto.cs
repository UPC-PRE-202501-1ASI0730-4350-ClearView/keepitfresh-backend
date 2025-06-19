namespace KeepItFresh.Platform.API.Inventory.Interfaces.REST.Resources;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ExpirationDate { get; set; } = null!;
    public string? Image { get; set; }
    public SensorDto? Sensor { get; set; }
    public DateTime CreatedAt { get; set; }

}
