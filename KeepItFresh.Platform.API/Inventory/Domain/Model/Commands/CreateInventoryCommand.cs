namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;

public record CreateInventoryCommand(int Id, int Quantity, int ProductId, int SupplierId);