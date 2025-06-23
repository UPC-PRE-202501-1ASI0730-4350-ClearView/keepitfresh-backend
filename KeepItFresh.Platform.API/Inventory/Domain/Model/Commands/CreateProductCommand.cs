namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Commands;
public record CreateProductCommand(string Name,
    string Category,
    int Quantity,
    decimal Price,
    DateTime ExpirationDate,
    string? Image);