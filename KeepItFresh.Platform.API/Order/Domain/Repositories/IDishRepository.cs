using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Order.Domain.Repositories;

public interface IDishRepository
{
    Task<IEnumerable<Dish>> FindByNameAsync(string name);
    Task<bool> ExistsByNameAsync(string name);
}