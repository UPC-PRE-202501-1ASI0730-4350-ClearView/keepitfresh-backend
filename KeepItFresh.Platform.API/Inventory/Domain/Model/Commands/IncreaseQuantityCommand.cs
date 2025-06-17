namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;

public record IncreaseQuantityCommand(int Quantity, int ProductId);
