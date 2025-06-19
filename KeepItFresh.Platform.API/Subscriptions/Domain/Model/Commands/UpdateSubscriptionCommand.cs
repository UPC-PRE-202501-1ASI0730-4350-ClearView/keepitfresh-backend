namespace KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;

public record UpdateSubscriptionCommand(
    Guid UserId,
    string Type,
    DateTime StartDate,
    DateTime EndDate);