using BackendEssentials.Domain.Entities;
using BackendEssentials.Features.CartItems.CreateCartItem;

namespace BackendEssentials.Features.Carts.Commands.CreateCart;

public record CreateCartRequest
{
    public List<CreateCartItemRequest> Items { get; set; } = new List<CreateCartItemRequest>();
}