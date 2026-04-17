using MediatR;
using projectingPatterns.Application.Common.Interfaces;

namespace projectingPatterns.Application.Products.Commands;

public record DeleteProductCommand(long ProductId) :  IRequest<bool>;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        ArgumentNullException.ThrowIfNull(product);
        product.IsDeleted = true;
        var result = await _productRepository.DeleteAsync(product, cancellationToken);
        return result;
    }
}