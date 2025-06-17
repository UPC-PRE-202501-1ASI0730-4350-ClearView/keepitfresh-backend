using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Domain.Repositories;
using KeepItFresh.Platform.API.Control.Domain.Services;

namespace KeepItFresh.Platform.API.Control.Application.Internal.CommandServices;

public class InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork) 
    : IInventoryCommandService
{
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        var inventory = await inventoryRepository.findByNameAsync(command.Name);
        
        if (inventory != null)
            throw new Exception("Inventory with this name already exists");

        inventory = new Inventory(command);

        try
        {
            await inventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        
        return inventory;
    }

    public async Task<Inventory?> Handle(DecreaseQuantityCommand command)
    {
        return await HandleQuantityCommand(command.ProductId, 
            command.Quantity, inventory => inventory.DecreaseQuantity(command));
    }

    public async Task<Inventory?> Handle(IncreaseQuantityCommand command)
    {
        return await HandleQuantityCommand(command.ProductId, 
            command.Quantity, inventory => inventory.IncreaseQuantity(command));
    }

    public async Task<Inventory?> Handle(UpdateProductOwnerCommand command)
    {
        var product = await inventoryRepository.FindByIdAsync(command.ProductId);
        
        if (product == null)
            throw new ArgumentException(" Product not found");

        try
        {
            product.UpdateProductOwner(command);
            inventoryRepository.Update(product);
            await unitOfWork.CompleteAsync();

            return product;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Inventory?> Handle(UpdateSupplierOwnerCommand command)
    {
        var supplier = await inventoryRepository.FindByIdAsync(command.SupplierId);
        
        if (supplier == null)
            throw new ArgumentException("Supplier not found");

        try
        {
            supplier.UpdateSupplierOwner(command);
            inventoryRepository.Update(supplier);
            await unitOfWork.CompleteAsync();

            return supplier;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task Handle(DeleteInventoryCommand command)
    {
        var inventory = await inventoryRepository.FindByIdAsync(command.Id);

        if (inventory == null)
            throw new ArgumentException("Inventory not found");

        try
        {
            inventoryRepository.Remove(inventory);
            await unitOfWork.CompleteAsync();
        } 
        catch (Exception e)
        {
            throw new Exception("An error occurred while deleting the inventory", e);
        }
    }

    private async Task<Inventory?> HandleQuantityCommand(int productId, int quantity,
        Action<Inventory> modifyQuantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        var product = await inventoryRepository.FindByIdAsync(productId);

        if (product == null)
            throw new ArgumentException("Product not found");

        modifyQuantity(product);

        try
        {
            inventoryRepository.Update(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception)
        {
            return null;
        }
    }
}