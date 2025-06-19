using KeepItFresh.Platform.API.Sensor.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Sensor.Domain.Model.Commands;
using KeepItFresh.Platform.API.Sensor.Domain.Services;

namespace KeepItFresh.Platform.API.Sensor.Application.Internal.CommandServices;

public class SensorCommandService
{
    private readonly IInventoryGateway _inventory;

    public SensorCommandService(IInventoryGateway inventory)
    {
        _inventory = inventory;
    }

    public async Task Handle(AssignSensorCommand command)
    {
        var products = await _inventory.GetAllProductsAsync();
        var product = products.FirstOrDefault(p => p.Id == command.ProductId);
        if (product is null) throw new InvalidOperationException("Product not found.");

        var sensor = new SensorAggregate(command.Type, command.Status, product);

        product.Sensor = new ProductDto.SensorData
        {
            Id = sensor.Id,
            Type = sensor.Type,
            Status = sensor.Status
        };

        await _inventory.UpdateProductAsync(command.ProductId, product);
    }
    
    public async Task Handle(UpdateSensorCommand command)
    {
        await Handle(new AssignSensorCommand(command.ProductId, command.Type, command.Status));
    }
}