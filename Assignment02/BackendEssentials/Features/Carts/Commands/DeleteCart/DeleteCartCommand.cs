using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Commands.DeleteCart;

public record DeleteCartCommand(long CartId) : IRequest;

public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.DeleteAsync(request.CartId);
    }
}