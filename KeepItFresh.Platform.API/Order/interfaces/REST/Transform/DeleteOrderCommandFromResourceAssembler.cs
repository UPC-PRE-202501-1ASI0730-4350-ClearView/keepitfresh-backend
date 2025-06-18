using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Order.interfaces.REST.Transform;

public class DeleteOrderCommandFromResourceAssembler
{
    public static DeleteOrderCommand ToCommandFromResource(
        DeleteOrderResource resource)
    {
        return new DeleteOrderCommand(resource.Id);
    }

}