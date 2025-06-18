using KeepItFresh.Platform.API.Order.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public partial class Orders : IStatus
{
    
    public EOrderStatus Status { get; protected set; }

    public Orders()
    {
        Name = string.Empty;
    }
    
    
    
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

    public void SendToCancelled()
    {
        Status = EOrderStatus.Canceled;
    }
}