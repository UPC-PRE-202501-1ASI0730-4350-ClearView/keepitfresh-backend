namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;

public record CreateInventoryCommand(int Id, string Name, int Quantity, int ProductId, int SupplierId);