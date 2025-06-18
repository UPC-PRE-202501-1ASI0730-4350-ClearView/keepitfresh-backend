using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory inventory)
    {
        return new InventoryResource(inventory.Id, new ProductId(inventory.ProductId), 
            new SupplierId(inventory.SupplierId), inventory.Name, inventory.Quantity);
    }
}