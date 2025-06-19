using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Transform;

public class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription subscription)
    {
        return new SubscriptionResource(
            subscription.Id,
            subscription.UserId,
            subscription.Type,
            subscription.StartDate,
            subscription.EndDate
        );
    }
}