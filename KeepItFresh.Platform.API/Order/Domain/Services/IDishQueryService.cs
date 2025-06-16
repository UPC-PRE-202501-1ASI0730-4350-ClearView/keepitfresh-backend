using KeepItFresh.Platform.API.Order.Domain.Model.Entities;
using KeepItFresh.Platform.API.Order.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IDishQueryService
{
    Task<IEnumerable<Dish>> HandleGetAllDishes();
    Task<Dish?> HandleGetDishById(GetDishByIdQuery query);
}