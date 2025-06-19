public record CreateSubscriptionResource(
    Guid UserId,
    string Type,
    DateTime StartDate,
    DateTime EndDate);