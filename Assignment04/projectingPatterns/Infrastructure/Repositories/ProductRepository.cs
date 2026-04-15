using Microsoft.EntityFrameworkCore;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Domain.Entities;
using projectingPatterns.Infrastructure.Data;

namespace projectingPatterns.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _context.Products.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken)
    {
        var result = await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var result =await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        return result;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var result = _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);
        return await _context.SaveChangesAsync() > 0;
    }
}