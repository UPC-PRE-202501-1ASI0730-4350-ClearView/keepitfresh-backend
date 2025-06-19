using KeepItFresh.Platform.API.Profiles.Domain.Model.Commands;
using KeepItFresh.Platform.API.Profiles.Domain.Model.Queries;
using KeepItFresh.Platform.API.Profiles.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Profiles.Domain.Services;
using KeepItFresh.Platform.API.Profiles.Interfaces.ACL;

namespace KeepItFresh.Platform.API.Profiles.Application.ACL;

public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService
) : IProfilesContextFacade
{
        
    // inheritedDoc
    public async Task<int> CreateProfile(string firstName, string lastName, string email)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    // inheritedDoc
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}