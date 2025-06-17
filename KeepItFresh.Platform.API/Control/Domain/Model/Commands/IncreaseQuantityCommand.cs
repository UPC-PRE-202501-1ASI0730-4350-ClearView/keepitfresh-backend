namespace KeepItFresh.Platform.API.Control.Domain.Model.Commands;

public record IncreaseQuantityCommand(int Quantity, int InventoryId);
