using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IOrderCommandService
{
    Task<Model.Aggregates.Order?> Handle(CreateOrderCommand command);
    
}