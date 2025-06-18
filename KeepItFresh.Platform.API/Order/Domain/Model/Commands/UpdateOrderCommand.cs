namespace KeepItFresh.Platform.API.Order.Domain.Model.Commands;

public record UpdateOrderCommand(int OrderId, string Name, int Price);