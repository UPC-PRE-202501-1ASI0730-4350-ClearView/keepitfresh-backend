using KeepItFresh.Platform.API.IAM.Application.ACL;

namespace KeepItFresh.Platform.API.IAM.Application.Internal.OutboundServices;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade)
{
    public async Task<int> CreateProfile(string fullName, string email, string userId)
    {
        return await profilesContextFacade.CreateProfileAsync(fullName, email, userId);
    }
}