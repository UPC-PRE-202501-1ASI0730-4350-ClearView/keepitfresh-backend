namespace KeepItFresh.Platform.API.Profiles.Domain.Model.ValueObjects;

public record EmailAddress(string Address = "")
{
    public override string ToString() => Address;
};