using KeepItFresh.Platform.API.IAM.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.IAM.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    
    Task<(User user, string Token)> Handle(LogInCommand command);
}