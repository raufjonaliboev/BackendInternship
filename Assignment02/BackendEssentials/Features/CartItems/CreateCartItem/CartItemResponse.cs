namespace BackendEssentials.Features.CartItems.CreateCartItem;

public record CartItemResponse
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal => Quantity * UnitPrice;
}