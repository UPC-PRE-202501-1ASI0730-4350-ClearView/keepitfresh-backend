namespace KeepItFresh.Platform.API.Control.Domain.Model.Commands;

public record CreateInventoryCommand(string Name, int Quantity, int ProductId, int SupplierId);