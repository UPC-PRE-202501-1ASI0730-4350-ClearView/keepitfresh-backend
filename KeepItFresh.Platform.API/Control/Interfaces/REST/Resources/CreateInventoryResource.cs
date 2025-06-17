namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

public record CreateInventoryResource(string Name, int Quantity, int ProductId, int SupplierId);