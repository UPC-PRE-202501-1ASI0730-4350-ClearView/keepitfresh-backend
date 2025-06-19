using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public string Category { get; private set; }
    public decimal Price { get; private set; }
    public string? Image { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public Product() {}

    public Product(string name, string category, int quantity, decimal price, DateTime expirationDate, string? image = null)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        Price = price;
        ExpirationDate = expirationDate;
        Image = image;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateInfo(string name, string category, int quantity, decimal price, DateTime expirationDate, string? image)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        Price = price;
        ExpirationDate = expirationDate;
        Image = image;
    }
    
    public SensorData? Sensor { get; private set; }

    public void AssignSensor(SensorData sensor)
    {
        Sensor = sensor;
    }
    
    public bool IsExpired() => ExpirationDate < DateTime.UtcNow;
    
    public bool HasStock(int requestedQuantity) => Quantity >= requestedQuantity;
    
    public bool HasSensor() => Sensor is not null;
    
    public void DecreaseStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than 0.");
        if (!HasStock(amount)) throw new InvalidOperationException("Insufficient stock.");
    
        Quantity -= amount;
    }

}