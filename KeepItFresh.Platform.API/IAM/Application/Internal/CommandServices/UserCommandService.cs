using KeepItFresh.Platform.API.IAM.Application.Internal.OutboundServices;
using KeepItFresh.Platform.API.IAM.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork,
    ExternalProfileService externalProfileService
    ) 
{
    
}