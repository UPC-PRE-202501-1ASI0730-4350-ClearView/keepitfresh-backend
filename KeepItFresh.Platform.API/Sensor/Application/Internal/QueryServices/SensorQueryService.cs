using KeepItFresh.Platform.API.Sensor.Domain.Model.Queries;
using KeepItFresh.Platform.API.Sensor.Domain.Services;

namespace KeepItFresh.Platform.API.Sensor.Application.Internal.QueryServices;

public class SensorQueryService
{
    private readonly IInventoryGateway _inventory;

    public SensorQueryService(IInventoryGateway inventory)
    {
        _inventory = inventory;
    }

    public async Task<List<ProductDto>> Handle(GetAvailableProductsQuery query)
    {
        var products = await _inventory.GetAllProductsAsync();
        return products.Where(p => p.Sensor == null).ToList();
    }

    public async Task<List<ProductDto>> Handle(GetAssignedProductsQuery query)
    {
        var products = await _inventory.GetAllProductsAsync();
        return products.Where(p => p.Sensor != null).ToList();
    }
}