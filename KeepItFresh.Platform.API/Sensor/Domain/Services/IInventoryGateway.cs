namespace KeepItFresh.Platform.API.Sensor.Domain.Services;

public interface IInventoryGateway
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task UpdateProductAsync(int productId, ProductDto product);
}

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ExpirationDate { get; set; } = default!;
    public string? Image { get; set; }
    public SensorData? Sensor { get; set; }
    
    

    public class SensorData
    {
        public string Id { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}