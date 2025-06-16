using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IDishQueryServices
{
    Task<IEnumerable<Dish>> Handle(GetAllDishesQuery query);
    Task<Dish> Handle(GetDishByIdQuery query);
    Task<Dish> Handle(GetDishByNameQuery query);
}