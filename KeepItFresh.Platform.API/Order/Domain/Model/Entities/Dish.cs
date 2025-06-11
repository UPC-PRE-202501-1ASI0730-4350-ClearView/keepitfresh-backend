using KeepItFresh.Platform.API.Order.Domain.Model.valueObjects;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Entities;

public class Dish : ICompletion
{
    public int Id { get; }
    
    public string Name { get; set; }
    
    public int Price { get; set; }

    public EOrderStatus Status { get; private set; } = EOrderStatus.Pending;


    
    public void SendToPrepare()
    {
        Status = EOrderStatus.Preparing;
    }

    public void SendToReady()
    {
        Status = EOrderStatus.Ready;
    }

    public void SendToCompleted()
    {
        Status = EOrderStatus.Completed;
    }

    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }
}