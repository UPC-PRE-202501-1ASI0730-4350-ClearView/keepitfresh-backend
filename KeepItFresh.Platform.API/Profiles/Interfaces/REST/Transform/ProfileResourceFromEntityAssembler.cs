using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Profiles.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress);
    }
}