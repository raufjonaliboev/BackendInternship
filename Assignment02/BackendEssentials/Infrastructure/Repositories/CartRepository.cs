using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using BackendEssentials.Domain.Entities;
using BackendEssentials.Domain.Enums;
using BackendEssentials.Features.Carts.Commands.CreateCart;
using BackendEssentials.Features.Carts.Commands.UpdateCart;
using BackendEssentials.Features.Common.Extensions;
using BackendEssentials.Features.Common.Interfaces;

namespace BackendEssentials.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly List<CartEntity> _carts = new List<CartEntity>();
    
    public Task CreateAsync(CreateCartRequest cartRequest)
    {
        var cart = new CartEntity
        {
            Id = _carts.Count + 1,
            DeviceId = Guid.NewGuid().ToString(),
            Items = new List<CartItemEntity>(),
        };

        foreach (var item in cartRequest.Items)
        {
            var cartItem = new CartItemEntity
            {
                CartId = cart.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                CreatedAt = DateTime.UtcNow,
            };
            cart.Items.Add(cartItem);
        }
        
        _carts.Add(cart);
        Console.WriteLine($"Created cart: {cart.Id}");
        return Task.CompletedTask;
    }

    public Task UpdateAsync(long cartId, UpdateCartRequest cartRequest)
    {
       var cart = _carts.FirstOrDefault(c => c.Id == cartId);
       
       if (cart == null)
       {
           Console.WriteLine("Cart not found");
           return Task.CompletedTask;
       }
        
       cart.DeviceId = cartRequest.DeviceId;
       
       Console.WriteLine("Cart updated");
       return Task.CompletedTask;
    }

    public Task DeleteAsync(long cartId)
    {
        var cart = _carts.FirstOrDefault(c => c.Id == cartId);
        if (cart == null)
        {
            Console.WriteLine("Cart not found");
            return Task.CompletedTask;
        }
        
        _carts.Remove(cart);
        Console.WriteLine($"Cart {cart.Id} - was deleted!");
        return Task.CompletedTask;
    }

    public Task GetAsync(long cartId)
    {
        var cart = _carts.FirstOrDefault(c => c.Id == cartId);
        if (cart == null)
        {
            Console.WriteLine("Cart not found");
        }
        else
        {
            cart.PrintCart();
        }
        return Task.CompletedTask;
    }

    public Task GetAllAsync()
    {
        foreach (var cart in _carts)
        {
            cart.PrintCart();
        }
        return Task.CompletedTask;
    }

    public Task GetCancelledAsync()
    {
        var cancelledCarts = _carts.Where(c=> c.Status == CartStatus.Cancelled).ToList();

        foreach (var cart in cancelledCarts)
        {
            cart.PrintCart();
        }
        return Task.CompletedTask;
    }
    
    public Task GetCompletedAsync()
    {
        var completedCarts = _carts
            .Where(c=> c.Status == CartStatus.Completed)
            .SelectMany(c => c.Items,
                (c, items)  => new
                    {
                        c.DeviceId,
                        items.ProductId,
                        items.Quantity,
                        items.UnitPrice,
                    })
            .ToList();

        foreach (var cart in completedCarts)
        {
            Console.WriteLine($"DeviceId: {cart.DeviceId}" + 
                              $"ProducId: {cart.ProductId}" +
                              $"Staus: {cart.Quantity} " +
                              $"DeviceId: {cart.UnitPrice}");
        }
        return Task.CompletedTask;
    }
}