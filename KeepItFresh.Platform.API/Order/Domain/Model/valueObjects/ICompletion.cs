namespace KeepItFresh.Platform.API.Order.Domain.Model.valueObjects;

/// <summary>
/// Represents the behaviors that can affect the status of an Order.
/// </summary>

public interface ICompletion
{
    void SendToPrepare();

    void SendToReady();
    
    void SendToCompleted();
    
    void Dispose();
}