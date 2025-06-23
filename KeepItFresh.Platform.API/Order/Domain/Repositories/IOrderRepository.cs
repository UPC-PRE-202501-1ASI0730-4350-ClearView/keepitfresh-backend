using KeepItFresh.Platform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Order.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Order.Domain.Repositories;
  
public interface IOrderRepository : IBaseRepository<Orders>
{
    Task<IEnumerable<Orders>> FindByNameAsync(string name);
}