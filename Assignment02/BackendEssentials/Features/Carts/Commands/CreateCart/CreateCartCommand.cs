using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Commands.CreateCart;

public record CreateCartCommand(CreateCartRequest CartRequest) : IRequest;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand>
{
    private readonly ICartRepository _cartRepository;

    public CreateCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.CreateAsync(request.CartRequest);
    }
}