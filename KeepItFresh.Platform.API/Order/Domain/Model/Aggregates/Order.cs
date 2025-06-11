using KeepItFresh.Platform.API.Order.Domain.Model.Entities;
using KeepItFresh.Platform.API.Order.Domain.Model.valueObjects;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public ICollection<Dish> Dishes { get; }
    public int Price { get; private set; }
    public EOrderStatus Status { get; private set; } = EOrderStatus.Pending;

    public Order(int price, string status)
    {
        Price = price;
    }

    private bool HasAllDishesWithStatus(EOrderStatus status)
    {
        return Dishes.All(dish => dish.Status == status);
    }

    public void SendToPending()
    {
        if (HasAllDishesWithStatus(EOrderStatus.Pending))
        {
            Status = EOrderStatus.Pending;
        }
    }

    public void SendToPrepare()
    {
        if (HasAllDishesWithStatus(EOrderStatus.Preparing))
        {
            Status = EOrderStatus.Preparing;
        }
    }

    public void SendToReady()
    {
        if (HasAllDishesWithStatus(EOrderStatus.Ready))
        {
            Status = EOrderStatus.Ready;
        }
    }

    public void SendToCompleted()
    {
        if (HasAllDishesWithStatus(EOrderStatus.Completed))
        {
            Status = EOrderStatus.Completed;
        }
    }

    public void SendToCancelled()
    {
        if (HasAllDishesWithStatus(EOrderStatus.Canceled))
        {
            Status = EOrderStatus.Canceled;
        }
    }
}
