using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Order.interfaces.REST.Transform;

public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource( 
        CreateOrderResource resource)
    {
        return new CreateOrderCommand(
            resource.Name,
            resource.Price,
            resource.DishesId);
    }
}