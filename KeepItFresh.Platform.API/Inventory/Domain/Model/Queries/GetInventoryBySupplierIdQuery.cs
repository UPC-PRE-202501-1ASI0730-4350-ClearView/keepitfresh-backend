using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Queries;

public record GetInventoryBySupplierIdQuery(int SupplierId);