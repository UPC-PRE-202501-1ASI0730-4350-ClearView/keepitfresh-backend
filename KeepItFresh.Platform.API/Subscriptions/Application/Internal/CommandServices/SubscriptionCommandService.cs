using KeepItFresh.Platform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;
using KeepItFresh.Platform.API.Subscriptions.Domain.Repositories;
using KeepItFresh.Platform.API.Subscriptions.Domain.Services;

namespace KeepItFresh.Platform.API.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<Subscription> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        await _subscriptionRepository.CreateAsync(subscription);
        return subscription;
    }

    public async Task<Subscription?> Handle(UpdateSubscriptionCommand command)
    {
        var subscription = await _subscriptionRepository.FindByUserIdAsync(command.UserId);
        if (subscription == null) return null;

        subscription.UpdateFromCommand(command);

        await _subscriptionRepository.UpdateAsync(subscription);
        return subscription;
    }
    
}