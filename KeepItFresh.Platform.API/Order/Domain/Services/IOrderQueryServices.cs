using KeepItFresh.Platform.API.Order.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IOrderQueryServices
{
    Task<IEnumerable<Model.Aggregates.Order>> Handle(GetAllOrdersQuery query);
    Task<Model.Aggregates.Order> Handle(GetOrderByIdQuery query);
}