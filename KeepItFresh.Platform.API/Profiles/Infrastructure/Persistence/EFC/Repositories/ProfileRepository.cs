using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Profiles.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Profiles.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KeepItFresh.Platform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;


/// <summary>
/// Profile repository implementation  
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class ProfileRepository(AppDbContext context)
: BaseRepository<Profile>(context), IProfileRepository
{
    public async Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().FirstOrDefault(p => p.Email == email);
    }
}