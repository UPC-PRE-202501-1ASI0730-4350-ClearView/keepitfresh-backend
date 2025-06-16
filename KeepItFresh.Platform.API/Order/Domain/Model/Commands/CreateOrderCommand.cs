using KeepItFresh.Platform.API.Order.Domain.Model.valueObjects;

namespace KeepItFresh.Platform.API.Order.Domain.Model.Commands;

public record CreateOrderCommand(int Price, EOrderStatus Status);