using BackendEssentials.Features.Common.Interfaces;
using MediatR;

namespace BackendEssentials.Features.Carts.Queries.GetCompletedCarts;

public record GetCompletedCartsQuery : IRequest;

public class GetCompletedCartsQueryHandler : IRequestHandler<GetCompletedCartsQuery>
 {
     private readonly ICartRepository _cartRepository;

     public GetCompletedCartsQueryHandler(ICartRepository cartRepository)
     {
         _cartRepository = cartRepository;
     }

     public async Task Handle(GetCompletedCartsQuery request, CancellationToken cancellationToken)
     {
         await _cartRepository.GetCompletedAsync();
     }
 }