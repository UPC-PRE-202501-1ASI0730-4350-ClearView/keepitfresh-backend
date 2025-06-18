using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Order.interfaces.REST.Transform;

public class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(UpdateOrderResource resource)
    {
        return new UpdateOrderCommand(
            resource.Id,
            resource.Name,
            resource.Price);
    }
}