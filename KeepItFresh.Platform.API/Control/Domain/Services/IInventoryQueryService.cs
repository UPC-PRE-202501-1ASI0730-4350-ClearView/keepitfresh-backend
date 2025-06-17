using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Model.Queries;

namespace KeepItFresh.Platform.API.Control.Domain.Services;

public interface IInventoryQueryService
{
    Task<IEnumerable<Inventory>> Handle(GetInventoryByProductIdQuery query);
    Task<IEnumerable<Inventory>> Handle(GetInventoryBySupplierIdQuery query);
    Task<Inventory?> Handle(GetInventoryByIdQuery query);
    Task<Inventory?> Handle(GetInventoryByNameQuery query);
    Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query);
}