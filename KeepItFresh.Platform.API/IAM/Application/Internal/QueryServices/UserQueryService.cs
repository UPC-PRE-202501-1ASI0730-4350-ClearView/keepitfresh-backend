using KeepItFresh.Platform.API.IAM.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.IAM.Domain.Model.Queries;
using KeepItFresh.Platform.API.IAM.Domain.Repositories;
using KeepItFresh.Platform.API.IAM.Domain.Services;

namespace KeepItFresh.Platform.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
}