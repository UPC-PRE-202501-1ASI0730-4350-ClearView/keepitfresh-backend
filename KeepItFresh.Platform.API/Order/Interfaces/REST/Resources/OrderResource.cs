namespace KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

public record OrderResource(
    long Id,
    string Name,
    string Dishes,
    int Price);