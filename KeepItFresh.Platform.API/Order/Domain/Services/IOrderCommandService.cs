using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IOrderCommandService
{
     public Task<Orders?> Handle(CreateOrderCommand command);
     public Task<Orders?> Handle(DeleteOrderCommand command);
}