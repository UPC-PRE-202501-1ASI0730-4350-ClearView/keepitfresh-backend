namespace KeepItFresh.Platform.API.Control.Domain.Model.Commands;

public record DecreaseQuantityCommand(int Quantity, int ProductId);