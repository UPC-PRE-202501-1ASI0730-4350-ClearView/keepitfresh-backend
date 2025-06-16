using KeepItFresh.Platform.API.Order.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IOrderCommandService
{
     public Task<Model.Aggregates.Order?> Handle(CreateOrderCommand command);
}