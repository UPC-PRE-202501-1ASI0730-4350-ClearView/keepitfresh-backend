using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Inventory.Domain.Model.Queries;
using KeepItFresh.Platform.API.Inventory.Domain.Repositories;

namespace KeepItFresh.Platform.API.Inventory.Application.Internal.QueryServices;

public class ProductQueryService
{
    private readonly IProductRepository _repository;

    public ProductQueryService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> Handle(ListProductsQuery query)
    {
        return await _repository.ListAsync();
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await _repository.FindByIdAsync(query.Id);
    }
}