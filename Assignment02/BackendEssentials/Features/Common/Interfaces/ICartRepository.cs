using BackendEssentials.Features.Carts.Commands.CreateCart;
using BackendEssentials.Features.Carts.Commands.UpdateCart;
using BackendEssentials.Features.Carts.Queries.GetCart;

namespace BackendEssentials.Features.Common.Interfaces;

public interface ICartRepository
{
    public Task CreateAsync(CreateCartRequest cartRequest);
    public Task UpdateAsync(long cartId, UpdateCartRequest cartRequest);
    public Task DeleteAsync(long cartId);
    public Task GetAsync(long cartId);
    public Task GetAllAsync();
    public Task GetCancelledAsync();
    public Task GetCompletedAsync();
}