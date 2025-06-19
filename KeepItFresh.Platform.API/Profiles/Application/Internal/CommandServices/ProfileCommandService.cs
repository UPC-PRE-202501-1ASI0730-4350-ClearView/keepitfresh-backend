using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Profiles.Domain.Model.Commands;
using KeepItFresh.Platform.API.Profiles.Domain.Repositories;
using KeepItFresh.Platform.API.Profiles.Domain.Services;

using KeepItFresh.Platform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(
    IProfileRepository profileRepository, 
    IUnitOfWork unitOfWork) 
    : IProfileCommandService
{
    /// <inheritdoc />
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            // Log error
            return null;
        }
    }
}