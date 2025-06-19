using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;
using KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Subscriptions.Interfaces.REST.Transform;

public class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(
        CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(
            resource.UserId,
            resource.Type,
            resource.StartDate,
            resource.EndDate);
    }
}