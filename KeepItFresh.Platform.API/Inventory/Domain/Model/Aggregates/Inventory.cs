using KeepItFresh.Platform.API.Inventory.Domain.Model.ValueObjects;

namespace KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;

public partial class Inventory
{
    public int Id { get; private set; }
    public int Quantity { get; private set; }
    
    //campo solo para persistir el valor de la base de datos
    public long UserId;
    
    public ProductId ProductIdValue { get; private set; }
    public SupplierId SupplierIdValue { get; private set; }
}