using BackendEssentials.Domain.Common;

namespace BackendEssentials.Domain.Entities;

public class CartItemEntity : BaseAuditableEntity
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal => Quantity * UnitPrice;
}