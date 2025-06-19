namespace KeepItFresh.Platform.API.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, string fullName);