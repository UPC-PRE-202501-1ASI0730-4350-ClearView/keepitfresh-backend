using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;
using KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Transform;

public class UpdateSubscriptionCommandFromResourceAssembler
{
    public static UpdateSubscriptionCommand ToCommandFromResource(UpdateSubscriptionResource resource)
    {
        return new UpdateSubscriptionCommand(
            resource.UserId,
            resource.Type,
            resource.StartDate,
            resource.EndDate
        );
    }
}