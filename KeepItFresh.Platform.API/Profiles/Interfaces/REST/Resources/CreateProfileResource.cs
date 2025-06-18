namespace KeepItFresh.Platform.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(
    string FirstName, 
    string LastName, 
    string Email
    );