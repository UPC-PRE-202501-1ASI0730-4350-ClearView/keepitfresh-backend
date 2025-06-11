namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public string Name { get; private set; }
    public int Price {get; private set;}

    public Order(string name, int price)
    {
        Name = name;
        Price = price;
    }
}