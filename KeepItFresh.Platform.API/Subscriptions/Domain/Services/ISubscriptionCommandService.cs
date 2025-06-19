using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Subscriptions.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
    Task<Subscription?> Handle(UpdateSubscriptionCommand command);
}