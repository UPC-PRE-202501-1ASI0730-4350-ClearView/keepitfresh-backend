namespace KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public int Price {get; private set;}
    public string Status { get; private set; }

    public Order( int price, string status)
    {
        Price = price;
        Status = status;
    }
}