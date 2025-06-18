using KeepItFresh.Platform.API.Order.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public partial class Orders
{
    public int Id { get; }
    public string Name { get; private set; }
    public List<Dish> Dishes { get; private set; } = new List<Dish>();

    
    public Orders(string name)
    {
        Name = name;
    }

    public Orders(CreateOrderCommand command)
    {
        this.Name = command.Name;
    }
    
    
}