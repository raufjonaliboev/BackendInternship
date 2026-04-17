using MediatR;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Application.Products.Queries;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllAsync(cancellationToken);
        return result;
    }
}