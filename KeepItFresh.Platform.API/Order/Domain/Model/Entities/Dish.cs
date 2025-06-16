namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public class Dish
{
    public int Id { get; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    
    public Dish()
    {
        Name = string.Empty;
        Price = 0;
    }
    
    
    
    
}