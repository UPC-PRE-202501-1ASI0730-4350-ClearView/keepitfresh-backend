using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Order.interfaces.REST.Transform;

public class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Orders order)
    {
        return new OrderResource(order.Id, order.Name, order.Dishes, order.Price);
    }
}