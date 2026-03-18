using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Commands.UpdateCart;

public record UpdateCartCommand(long CartId, UpdateCartRequest UpdateCartRequest) : IRequest;

public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
{
    private readonly ICartRepository _cartRepository;

    public UpdateCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.UpdateAsync(request.CartId, request.UpdateCartRequest);
    }
}