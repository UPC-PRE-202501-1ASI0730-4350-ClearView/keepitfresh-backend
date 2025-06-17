using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class IncreaseQuantityCommandFromResourceAssembler
{
    public static IncreaseQuantityCommand ToCommandFromResource(IncreaseQuantityResource resource)
    {
        return new IncreaseQuantityCommand(resource.Quantity, (int)resource.ProductId);
    }
}