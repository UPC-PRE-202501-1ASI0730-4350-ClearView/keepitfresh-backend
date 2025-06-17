using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Control.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Control.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Control.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) 
    : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory?> findByNameAsync(string name)
    {
        return await Context.Set<Inventory>().FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Inventory>> findByProductIdAsync(int productId)
    {
        return await Context.Set<Inventory>().Where(p => p.ProductId == productId).ToListAsync();
    }

    public async Task<IEnumerable<Inventory>> findBySupplierIdAsync(int supplierId)
    {
        return await Context.Set<Inventory>().Where(p => p.SupplierId == supplierId).ToListAsync();
    }
}