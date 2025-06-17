using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class UpdateProductOwnerCommandFromResourceAssembler
{
    public static UpdateProductOwnerCommand ToCommandFromResource(UpdateProductOwnerResource resource)
    {
        return new UpdateProductOwnerCommand(resource.ProductId);
    }
}