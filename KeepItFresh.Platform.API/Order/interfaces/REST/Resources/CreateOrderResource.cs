namespace KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

public record CreateOrderResource(string Name, List<int> DishesId);