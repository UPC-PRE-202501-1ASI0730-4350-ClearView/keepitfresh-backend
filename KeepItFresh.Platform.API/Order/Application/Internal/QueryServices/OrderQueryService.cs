using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Services;

namespace KeepItFresh.Platform.API.Order.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository repository) : IOrderQueryServices
{
    public async Task<IEnumerable<Orders>> Handle(GetAllOrdersQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Orders?> Handle(GetOrderByIdQuery query)
    {
        return await repository.FindByIdAsync(query.id);
    }
}