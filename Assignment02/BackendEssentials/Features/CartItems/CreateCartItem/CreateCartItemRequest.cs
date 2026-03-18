namespace BackendEssentials.Features.CartItems.CreateCartItem;

public record CreateCartItemRequest
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}