using KeepItFresh.Platform.API.Control.Domain.Model.Commands;
using KeepItFresh.Platform.API.Control.Interfaces.REST.Resources;

namespace KeepItFresh.Platform.API.Control.Interfaces.REST.Transform;

public class UpdateSupplierOwnerCommandFromResourceAssembler
{
    public static UpdateSupplierOwnerCommand ToCommandFromResource(UpdateSupplierOwnerResource resource)
    {
        return new UpdateSupplierOwnerCommand(resource.SupplierId);
    }
}