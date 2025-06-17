using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IOrderQueryServices
{
    Task<IEnumerable<Orders>> Handle(GetAllOrdersQuery query);
    Task<Orders> Handle(GetOrderByIdQuery query);
}