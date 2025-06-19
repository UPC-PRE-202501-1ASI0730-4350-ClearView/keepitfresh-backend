namespace KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    Guid Id,
    Guid UserId,
    string Type,
    DateTime StartDate,
    DateTime EndDate
);
