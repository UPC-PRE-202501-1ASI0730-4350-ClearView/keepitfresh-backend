using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KeepItFresh.Platform.API.Order.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context)
    : BaseRepository<Orders>(context), IOrderRepository
{
    public Task<IEnumerable<Orders>> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}
