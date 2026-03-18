namespace BackendEssentials.Features.Carts.Commands.UpdateCart;

public record UpdateCartRequest
{
    public string DeviceId { get; set; } = string.Empty;
}