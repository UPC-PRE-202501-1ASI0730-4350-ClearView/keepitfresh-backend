using KeepItFresh.Platform.API.Order.Domain.Model.Commands;
using KeepItFresh.Platform.API.Order.Domain.Model.Entities;

namespace KeepItFresh.Platform.API.Order.Domain.Services;

public interface IDishCommandService
{
    Task<Dish?> Handle(CreateDishCommand command);
}