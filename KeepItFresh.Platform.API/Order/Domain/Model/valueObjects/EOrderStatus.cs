namespace KeepItFresh.Platform.API.Order.Domain.Model.ValueObjects;

/// <summary>
/// Represents the status of an Order.
/// </summary>

public enum EOrderStatus
{
    Pending,
    Preparing,
    Ready,
    Completed,
    Canceled
}