using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Queries.GetCarts;

public record GetCartsQuery : IRequest;

public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery>
{
    private readonly ICartRepository _cartRepository;

    public GetCartsQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task Handle(GetCartsQuery request, CancellationToken cancellationToken)
    {
        await _cartRepository.GetAllAsync();
    }
}