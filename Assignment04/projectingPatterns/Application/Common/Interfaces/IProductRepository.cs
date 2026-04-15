using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Application.Common.Interfaces;

public interface IProductRepository
{
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken);
}