namespace KeepItFresh.Platform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(string user);
    
    Task<int?> ValidateToken(string token);
    
}