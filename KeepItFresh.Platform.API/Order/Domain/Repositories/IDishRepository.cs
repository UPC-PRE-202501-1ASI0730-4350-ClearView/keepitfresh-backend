using KeepItFresh.Platform.API.Order.Domain.Model.Entities;

namespace KeepItFresh.Platform.API.Order.Domain.Repositories;

public interface IDishRepository
{
    Task<IEnumerable<Dish>> FindByOrderIdAsync(int orderId);
    Task<bool> ExistsByTitleAsync(string title);
}