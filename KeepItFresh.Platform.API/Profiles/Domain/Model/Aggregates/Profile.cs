using KeepItFresh.Platform.API.Profiles.Domain.Model.Commands;
using KeepItFresh.Platform.API.Profiles.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; }
    public EmailAddress Email { get; }
    
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();

    }

    public Profile(string firstName, string lastName, string email)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        
    }

}