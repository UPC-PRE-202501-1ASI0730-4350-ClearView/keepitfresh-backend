using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.Order.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Model.Aggregates.Order>
{
    Task<IEnumerable<Model.Aggregates.Order>> FindByNameAsync(string name);
}