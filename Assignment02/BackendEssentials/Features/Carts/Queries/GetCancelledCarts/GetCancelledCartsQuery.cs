using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Queries.GetCancelledCarts;

public record GetCancelledCartsQuery : IRequest;

public class GetCancelledCartsQueryHandler : IRequestHandler<GetCancelledCartsQuery>
{
    private readonly ICartRepository  _cartRepository;

    public GetCancelledCartsQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(GetCancelledCartsQuery request, CancellationToken cancellationToken)
    {
        await _cartRepository.GetCancelledAsync();
    }
}