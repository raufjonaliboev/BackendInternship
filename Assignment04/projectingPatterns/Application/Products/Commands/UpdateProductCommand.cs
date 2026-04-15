using MediatR;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Application.Products.Commands;

public record UpdateProductCommand(long ProductId, Product Product) :  IRequest<Product?>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product?>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        ArgumentNullException.ThrowIfNull(product);
        product.Name = request.Product.Name;
        product.Description = request.Product.Description;
        var result = await _productRepository.UpdateAsync(product, cancellationToken);
        return result;
    }
}