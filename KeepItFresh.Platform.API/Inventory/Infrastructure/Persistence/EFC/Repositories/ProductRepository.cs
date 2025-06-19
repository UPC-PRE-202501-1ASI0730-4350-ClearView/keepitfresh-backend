using KeepItFresh.Platform.API.Inventory.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> ListAsync() => await _context.Products.ToListAsync();
    public async Task<Product?> FindByIdAsync(int id) => await _context.Products.FindAsync(id);
    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
