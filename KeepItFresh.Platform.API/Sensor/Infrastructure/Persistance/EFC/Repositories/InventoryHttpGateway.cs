using KeepItFresh.Platform.API.Sensor.Domain.Services;

namespace KeepItFresh.Platform.API.Sensor.Infrastructure.Persistance.EFC.Repositories;

public class InventoryHttpGateway : IInventoryGateway
{
    private readonly HttpClient _httpClient;

    public InventoryHttpGateway(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductDto>>("http://localhost:5109/api/v1/products") ?? new();
    }

    public async Task UpdateProductAsync(int productId, ProductDto product)
    {
        await _httpClient.PutAsJsonAsync("http://localhost:5109/api/v1/products", product);
    }
}