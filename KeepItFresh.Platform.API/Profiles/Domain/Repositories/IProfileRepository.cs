using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Profiles.Domain.Model.ValueObjects;
using KeepItFresh.Platform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.Profiles.Domain.Repositories;


/// <summary>
/// Profile repository interface 
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    /// <summary>
    /// Find a profile by email 
    /// </summary>
    /// <param name="email">
    /// The <see cref="EmailAddress"/> email address to search for
    /// </param>
    /// <returns>
    /// The <see cref="Profile"/> if found, otherwise null
    /// </returns>
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}