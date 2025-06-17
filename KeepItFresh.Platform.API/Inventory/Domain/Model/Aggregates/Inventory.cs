using KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;
using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;

public partial class Inventory
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    
    //campo solo para persistir el valor de la base de datos
    public long ProductId;
    public long SupplierId;
    
    public ProductId ProductIdValue { get; private set; }
    public SupplierId SupplierIdValue { get; private set; }
    
    public Inventory() { }

    public Inventory(CreateInventoryCommand command)
    {
        ProductIdValue = new ProductId(command.ProductId);
        SupplierIdValue = new SupplierId(command.SupplierId);
        
        // Asignar solo el valor int para la persistencia
        ProductId = command.ProductId;
        SupplierId = command.SupplierId;
        
        Name = command.Name;
        Quantity = command.Quantity;
    }

    public void UpdateProductOwner(UpdateProductOwnerCommand command)
    {
        ProductIdValue = new ProductId(command.ProductId);
        ProductId = command.ProductId;
    }

    public void UpdateSupplierOwner(UpdateSupplierOwnerCommand command)
    {
        SupplierIdValue = new SupplierId(command.SupplierId);
        SupplierId = command.SupplierId;
    }

    public void IncreaseQuantity(IncreaseQuantityCommand command)
    {
        Quantity += command.Quantity;
    }

    public void DecreaseQuantity(DecreaseQuantityCommand command)
    {
        if (this.Quantity == 0)
            throw new InvalidOperationException("Product quantity is already 0");
        
        if (this.Quantity < command.Quantity)
            throw new InvalidOperationException("Product quantity is less than the quantity to decrease");

        Quantity -= command.Quantity;
    }
}