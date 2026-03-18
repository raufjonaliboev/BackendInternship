using BackendEssentials.Domain.Entities;
using BackendEssentials.Features.CartItems.CreateCartItem;

namespace BackendEssentials.Features.Carts.Queries.GetCart;

public record CartResponse
{
    public required string DeviceId { get; set; }
    public List<CartItemEntity> Items = new List<CartItemEntity>();
    public decimal Total { get; set; }
}