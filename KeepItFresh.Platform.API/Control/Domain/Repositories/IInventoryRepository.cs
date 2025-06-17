using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Control.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory?> findByNameAsync(string name);
    Task<IEnumerable<Inventory>> findByProductIdAsync(int productId);
    Task<IEnumerable<Inventory>> findBySupplierIdAsync(int supplierId);
}