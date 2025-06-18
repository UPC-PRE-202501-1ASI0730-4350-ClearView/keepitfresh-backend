using KeepItFresh.Platform.API.Sensor.Domain.Services;

namespace KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;

public class SensorApplicationService
{
    private readonly IInventoryGateway _inventory;

    public SensorApplicationService(IInventoryGateway inventory)
    {
        _inventory = inventory;
    }

    public async Task<List<ProductDto>> GetAvailableProductsAsync()
    {
        var products = await _inventory.GetAllProductsAsync();
        return products.Where(p => p.Sensor == null).ToList();
    }

    public async Task<List<ProductDto>> GetAssignedProductsAsync()
    {
        var products = await _inventory.GetAllProductsAsync();
        return products.Where(p => p.Sensor != null).ToList();
    }

    public async Task AssignSensorAsync(int productId, string type, string status)
    {
        var products = await _inventory.GetAllProductsAsync();
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return;

        product.Sensor = new ProductDto.SensorData
        {
            Id = $"S-{productId}",
            Type = type,
            Status = status
        };

        await _inventory.UpdateProductAsync(productId, product);
    }

    public async Task UpdateSensorAsync(int productId, string type, string status)
    {
        await AssignSensorAsync(productId, type, status);
    }
}