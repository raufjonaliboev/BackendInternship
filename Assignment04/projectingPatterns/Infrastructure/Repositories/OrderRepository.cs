using projectingPatterns.Application.Common.Interfaces;

namespace projectingPatterns.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    public async Task CreateOrder()
    {
        Console.WriteLine("Saving order to db");
    }
}