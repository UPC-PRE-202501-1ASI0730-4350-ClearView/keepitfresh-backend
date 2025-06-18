using KeepItFresh.Platform.API.Order.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public partial class Orders
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Dishes {get; private set;}
    public int Price { get; private set; }

    
    public Orders(string name, string dishes ,int price)
    {
        Name = name;
        Dishes = dishes;
        Price = price;
    }

    public Orders(CreateOrderCommand command)
    {
        this.Name = command.Name;
        this.Dishes = command.Dishes;
        this.Price = command.Price;
    }

    public Orders(UpdateOrderCommand command)
    {
        this.Name = command.Name;
        this.Dishes = command.Dishes;
        this.Price = command.Price;
    }
    
    
}