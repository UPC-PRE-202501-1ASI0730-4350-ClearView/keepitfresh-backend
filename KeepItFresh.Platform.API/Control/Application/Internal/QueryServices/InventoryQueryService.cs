using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Model.Queries;
using KeepItFresh.Platform.API.Control.Domain.Repositories;
using KeepItFresh.Platform.API.Control.Domain.Services;

namespace KeepItFresh.Platform.API.Control.Application.Internal.QueryServices;

public class InventoryQueryService(IInventoryRepository inventoryRepository) : IInventoryQueryService
{
    public Task<IEnumerable<Inventory>> Handle(GetInventoryByProductIdQuery query)
    {
        return inventoryRepository.findByProductIdAsync(query.ProductId);
    }

    public Task<IEnumerable<Inventory>> Handle(GetInventoryBySupplierIdQuery query)
    {
        return inventoryRepository.findBySupplierIdAsync(query.SupplierId);
    }

    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync((int)query.InventoryId);
    }

    public async Task<Inventory?> Handle(GetInventoryByNameQuery query)
    {
        return await inventoryRepository.findByNameAsync(query.Name);
    }

    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }
}