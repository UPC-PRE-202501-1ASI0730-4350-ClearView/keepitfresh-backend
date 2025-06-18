using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Order.interfaces.REST.Transform;

public class CreateDishCommandFromResourceAssembler
{
    public static CreateDishCommand ToCommandFromResource(CreateDishResource resource)
    {
        return new CreateDishCommand(
            resource.Name,
            resource.Price);
    }
}