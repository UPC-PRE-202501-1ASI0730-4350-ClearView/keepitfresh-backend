namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;

public record DecreaseQuantityCommand(int Quantity, int ProductId);