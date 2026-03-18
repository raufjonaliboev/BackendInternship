using BackendEssentials.Domain.Common;
using BackendEssentials.Domain.Entities;

namespace BackendEssentials.Features.Common.Extensions;

public static class PrintExtensions
{
    public static void PrintCart(this CartEntity cart)
    {
        Console.WriteLine($"\nCart {cart.Id} - was retrieved!");
        Console.WriteLine($"Device Id: {cart.DeviceId}");
        Console.WriteLine($"Items Count: {cart.Items.Count}");
        Console.WriteLine($"Total Price: {cart.Total}");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"Product Id: {item.ProductId}");
            Console.WriteLine($"Quantity: {item.Quantity}");
            Console.WriteLine($"Unit Price: {item.UnitPrice}");
        }
    }
}