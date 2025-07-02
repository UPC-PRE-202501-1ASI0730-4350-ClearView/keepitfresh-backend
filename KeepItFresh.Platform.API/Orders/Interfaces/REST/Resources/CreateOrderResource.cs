namespace KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

public record CreateOrderResource(string Name, string Dishes, int Price);