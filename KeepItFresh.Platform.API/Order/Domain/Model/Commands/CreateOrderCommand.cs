namespace KeepItFresh.Platform.API.Order.Domain.Model.Commands;

public record CreateOrderCommand(string Name,string Dishes, int Price);