using System.Collections.Generic;
using System.Threading.Tasks;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Queries;
using KeepItFresh.Platform.API.Subscriptions.Domain.Repositories;
using KeepItFresh.Platform.API.Subscriptions.Domain.Services;

namespace KeepItFresh.Platform.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService : ISubscriptionQueryService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionQueryService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<Subscription?> Handle(GetSubscriptionByUserIdQuery query)
    {
        return await _subscriptionRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await _subscriptionRepository.ListAsync();
    }
}