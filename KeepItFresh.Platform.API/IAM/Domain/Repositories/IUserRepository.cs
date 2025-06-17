using KeepItFresh.Platform.API.IAM.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    
    
    Task<bool> ExistsByUsername(string username);
}