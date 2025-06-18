namespace KeepItFresh.Platform.API.Order.interfaces.REST.Resources;

public record CreateOrderResource(string Name, int Price, List<int> DishesId);