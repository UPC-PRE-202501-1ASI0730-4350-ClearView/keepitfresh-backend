namespace KeepItFresh.Platform.API.Profiles.Interfaces.ACL;


/// <summary>
/// Profiles context facade interface: provides methods to interact with the profile context.
/// </summary>
public interface IProfilesContextFacade
{

    Task<int> CreateProfile(string firstName, string lastName, string email);
    

    Task<int> FetchProfileIdByEmail(string email);
}