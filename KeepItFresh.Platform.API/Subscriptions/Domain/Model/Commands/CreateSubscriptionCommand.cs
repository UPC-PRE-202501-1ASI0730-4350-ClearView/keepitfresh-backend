namespace KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;

public record CreateSubscriptionCommand(
    Guid UserId,
    string Type,
    DateTime StartDate,
    DateTime EndDate);