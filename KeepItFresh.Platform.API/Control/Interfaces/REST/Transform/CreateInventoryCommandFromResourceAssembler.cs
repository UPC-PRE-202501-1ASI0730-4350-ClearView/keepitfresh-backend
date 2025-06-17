using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.Name, 
            resource.Quantity, resource.ProductId, resource.SupplierId);
    }
}