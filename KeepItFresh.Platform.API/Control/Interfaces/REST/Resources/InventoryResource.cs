using KeepItFresh.Platform.API.Control.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

public record InventoryResource(
    long Id,
    ProductId ProductId,
    SupplierId SupplierId,
    string Name,
    int Quantity
    );