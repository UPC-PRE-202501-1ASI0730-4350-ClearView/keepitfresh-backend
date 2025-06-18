using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Order.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace KeepItFresh.Platform.API.Order.Infrastructure.Repositories;

public class DishRepository(AppDbContext context) : BaseRepository<Dish>(context), IDishRepository
{
    public Task<IEnumerable<Dish>> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}