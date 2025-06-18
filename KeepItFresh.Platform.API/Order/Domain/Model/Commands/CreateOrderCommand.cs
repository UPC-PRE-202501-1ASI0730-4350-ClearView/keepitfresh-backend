namespace KeepItFresh.Platform.API.Order.Domain.Model.Commands;

public record CreateOrderCommand(string Name, int Price, List<int> DishesId);