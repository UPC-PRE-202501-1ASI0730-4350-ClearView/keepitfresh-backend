using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Order.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context)
    : BaseRepository<Orders>(context), IOrderRepository
{
    public async Task<IEnumerable<Orders>> FindByNameAsync(string name)
    {
        return await Context.Set<Orders>().Where(p => p.Name == name).ToListAsync();
    }

    public async Task<IEnumerable<Orders>> FindByIdAsync(long id)
    {
        return await Context.Set<Orders>().Where(p => p.Id == id).ToListAsync();
    }
}
