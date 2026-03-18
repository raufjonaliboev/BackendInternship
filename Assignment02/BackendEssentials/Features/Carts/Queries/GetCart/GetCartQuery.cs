using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Queries.GetCart;

public record GetCartQuery(long CartId) : IRequest;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery>
{
    private readonly ICartRepository _cartRepository;

    public GetCartQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        await _cartRepository.GetAsync(request.CartId);
    }
}