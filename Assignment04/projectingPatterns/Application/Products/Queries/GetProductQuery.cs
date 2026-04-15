using MediatR;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Application.Products.Queries;

public record GetProductQuery(long ProductId) : IRequest<Product?>;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        return result;
    }
}