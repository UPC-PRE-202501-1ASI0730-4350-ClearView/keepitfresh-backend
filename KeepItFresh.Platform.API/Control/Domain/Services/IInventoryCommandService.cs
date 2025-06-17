using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Model.Commands;

namespace KeepItFresh.Platform.API.Control.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand command);
    Task<Inventory?> Handle(DecreaseQuantityCommand command);
    Task<Inventory?> Handle(IncreaseQuantityCommand command);
    Task<Inventory?> Handle(UpdateProductOwnerCommand command);
    Task<Inventory?> Handle(UpdateSupplierOwnerCommand command); 
    Task<Inventory?> Handle(DeleteInventoryCommand command);
}