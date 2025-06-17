using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class DecreaseQuantityCommandFromResourceAssembler
{
    public static DecreaseQuantityCommand ToCommandFromResource(DecreaseQuantityResource resource)
    {
        return new DecreaseQuantityCommand(resource.Quantity, (int)resource.ProductId);
    }
}