using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;
using KeepItFresh.Platform.API.Inventory.Domain.Repositories;

namespace KeepItFresh.Platform.API.Inventory.Application.Internal.CommandServices;

public class ProductCommandService
{
    private readonly IProductRepository _repository;

    public ProductCommandService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(CreateProductCommand command)
    {
        var product = new Product(
            command.Name,
            command.Category,
            command.Quantity,
            command.Price,
            command.ExpirationDate,
            command.Image
        );

        await _repository.AddAsync(product);
        return product;
    }

    public async Task<Product?> Handle(UpdateProductCommand command)
    {
        var product = await _repository.FindByIdAsync(command.Id);
        if (product is null) return null;

        product.UpdateInfo(
            command.Name,
            command.Category,
            command.Quantity,
            command.Price,
            command.ExpirationDate,
            command.Image
        );

        if (command.Sensor is not null)
        {
            product.AssignSensor(command.Sensor);
        }

        await _repository.UpdateAsync(product);
        return product;
    }

    public async Task<bool> Handle(DeleteProductCommand command)
    {
        var product = await _repository.FindByIdAsync(command.Id);
        if (product is null) return false;

        await _repository.DeleteAsync(product);
        return true;
    }
}