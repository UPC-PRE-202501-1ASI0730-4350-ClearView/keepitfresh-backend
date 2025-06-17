using KeepItFresh.Platform.API.Control.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Control.Domain.Model.Queries;

public record GetInventoryBySupplierIdQuery(int SupplierId);