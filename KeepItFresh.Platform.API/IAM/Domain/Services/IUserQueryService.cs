using KeepItFresh.Platform.API.IAM.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.IAM.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
}