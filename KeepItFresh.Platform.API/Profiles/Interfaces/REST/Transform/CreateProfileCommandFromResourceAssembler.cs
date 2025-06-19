using KeepItFresh.Platform.API.Profiles.Domain.Model.Commands;
using KeepItFresh.Platform.API.Profiles.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email
        );
    }
}