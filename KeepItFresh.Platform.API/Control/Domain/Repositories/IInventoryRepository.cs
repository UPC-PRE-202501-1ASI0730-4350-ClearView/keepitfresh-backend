using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace KeepItFresh.Platform.API.Control.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Model.Aggregates.Inventory>
{
    Task<Model.Aggregates.Inventory?> findByNameAync(string name);
    Task<IEnumerable<Model.Aggregates.Inventory>> findByProductIdAsync(int productId);
    Task<IEnumerable<Model.Aggregates.Inventory>> findBySupplierIdAsync(int supplierId);
}