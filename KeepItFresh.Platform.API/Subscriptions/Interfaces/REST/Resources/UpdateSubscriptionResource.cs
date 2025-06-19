public record UpdateSubscriptionResource(
    Guid UserId,
    string Type,
    DateTime StartDate,
    DateTime EndDate
);