namespace KeepItFresh.Platform.API.IAM.Application.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfileAsync(string fullName, string email, string userId);

    
    
    
    Task<int> FetchProfileIdByUserId(int userId);
}