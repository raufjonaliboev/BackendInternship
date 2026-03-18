using BackendEssentials.Domain.Common;
using BackendEssentials.Domain.Enums;

namespace  BackendEssentials.Domain.Entities;

public class CartEntity : BaseAuditableEntity
{
    public string DeviceId { get; set; } = string.Empty;
    public List<CartItemEntity> Items = new List<CartItemEntity>();
    public decimal Total => Items.Sum(i => i.Subtotal);
    public CartStatus Status { get; set; } = CartStatus.Active;
}

