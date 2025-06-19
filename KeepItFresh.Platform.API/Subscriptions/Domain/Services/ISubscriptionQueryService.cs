using KeepItFresh.Platform.API.Order.Domain.Model.Queries;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByUserIdQuery query);
}