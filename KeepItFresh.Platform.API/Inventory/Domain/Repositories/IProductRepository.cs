using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Inventory.Domain.Repositories;

public interface IProductRepository
{
    Task<List<Product>> ListAsync();
    Task<Product?> FindByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}