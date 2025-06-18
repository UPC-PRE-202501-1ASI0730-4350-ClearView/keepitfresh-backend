namespace KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

public record UpdateOrderResource(int Id, string Name, string Dishes, int Price);