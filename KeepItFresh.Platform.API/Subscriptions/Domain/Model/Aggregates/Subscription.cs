using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Type { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Constructor general
    public Subscription(Guid userId, string type, DateTime startDate, DateTime endDate)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        CreatedAt = DateTime.UtcNow;
    }

    // Constructor desde CreateCommand
    public Subscription(CreateSubscriptionCommand command)
    {
        Id = Guid.NewGuid();
        UserId = command.UserId;
        Type = command.Type;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
        CreatedAt = DateTime.UtcNow;
    }

    // Método de actualización desde UpdateCommand
    public void UpdateFromCommand(UpdateSubscriptionCommand command)
    {
        Type = command.Type;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
        UpdatedAt = DateTime.UtcNow;
    }
}