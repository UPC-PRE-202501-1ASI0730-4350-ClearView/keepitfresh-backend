namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public string Name { get; private set; }
    public List<Dish> Dishes { get; private set; } = new List<Dish>();

    public Order()
    {
        Name = string.Empty;
    }
    
    public Order(string name)
    {
        Name = name;
    }
    
    
}