﻿using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Profiles.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    /// <summary>
    /// Handle get all profiles 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllProfilesQuery"/> query
    /// </param>
    /// <returns>
    /// A list of <see cref="Profile"/> objects
    /// </returns>
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    
    /// <summary>
    /// Handle get profile by email 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProfileByEmailQuery"/> query
    /// </param>
    /// <returns>
    /// A <see cref="Profile"/> object or null
    /// </returns>
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    
    /// <summary>
    /// Handle get profile by id 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProfileByIdQuery"/> query
    /// </param>
    /// <see cref="Profile"/> object or null
    /// /returns>
    Task<Profile?> Handle(GetProfileByIdQuery query);
}