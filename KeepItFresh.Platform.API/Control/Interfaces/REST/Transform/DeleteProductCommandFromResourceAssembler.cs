using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class DeleteInventoryCommandFromResourceAssembler
{
    public static DeleteInventoryCommand ToCommandFromResource(DeleteInventoryResource resource)
    {
        return new DeleteInventoryCommand(resource.Id);
    }
}