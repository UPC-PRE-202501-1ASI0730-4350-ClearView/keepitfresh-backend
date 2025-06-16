namespace KeepItFresh.Platform.API.Order.Domain.Model.ValueObjects;

/// <summary>
///  IStatus interface defines the methods for managing the status of an order.
/// </summary>


public interface IStatus
{
    void SendToPrepare();

    void SendToReady();

    void SendToCompleted();
    
    void SendToCancelled();
}