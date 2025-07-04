﻿namespace KeepItFresh.Platform.API.Profiles.Domain.Model.Commands;
/// <summary>
/// Create Profile Command 
/// </summary>
/// <param name="FirstName">
/// The first name of the profile.
/// </param>
/// /// <param name="LastName">
/// The last name of the profile.
/// </param>
/// <param name="Email">
/// The email address of the profile.
/// </param>

public record CreateProfileCommand(string FirstName, string LastName, string Email);