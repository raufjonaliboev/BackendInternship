using MediatR;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Application.Products.Commands;

public record CreateProductCommand(Product Product) : IRequest<Product?>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product?>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.AddAsync(request.Product, cancellationToken);
        return result;
    }
}