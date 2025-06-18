using KeepItFresh.Platform.API.Order.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public partial class Orders
{
    public int Id { get; }
    public string Name { get; private set; }
    public List<Dish> Dishes { get; private set; } = new List<Dish>();
    public int Price { get; private set; }

    
    public Orders(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public Orders(CreateOrderCommand command)
    {
        this.Name = command.Name;
        this.Price = command.Price;
    }

    public Orders(UpdateOrderCommand command)
    {
        this.Name = command.Name;
        this.Price = command.Price;
    }
    
    
}