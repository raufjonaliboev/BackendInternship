using BackendEssentials.Features.CartItems.CreateCartItem;
using BackendEssentials.Features.Carts.Commands.CreateCart;
using BackendEssentials.Features.Carts.Commands.DeleteCart;
using BackendEssentials.Features.Carts.Commands.UpdateCart;
using BackendEssentials.Features.Carts.Queries.GetCancelledCarts;
using BackendEssentials.Features.Carts.Queries.GetCart;
using BackendEssentials.Features.Carts.Queries.GetCarts;
using BackendEssentials.Features.Carts.Queries.GetCompletedCarts;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BackendEssentials.Infrastructure.Repositories;
using BackendEssentials.Features.Common.Interfaces;


var services = new ServiceCollection();
services.AddLogging();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

services.AddSingleton<ICartRepository, CartRepository>();
var provider = services.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

Console.WriteLine("Demo backend essentials!");

while (true)
{
    Console.WriteLine("\n==== CART MENU ====");
    Console.WriteLine("1. Create Cart");
    Console.WriteLine("2. Get Cart");
    Console.WriteLine("3. Update Cart");
    Console.WriteLine("4. Delete Cart");
    Console.WriteLine("5. Get All Carts");
    Console.WriteLine("6. Get cancelled Carts");
    Console.WriteLine("7. Get cancelled Carts");
    Console.WriteLine("8. Exit");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            var createRequest = new CreateCartRequest
            {
                Items = new List<CreateCartItemRequest>
                {
                    new CreateCartItemRequest
                    {
                        ProductId = 12,
                        Quantity = 3,
                        UnitPrice = 10
                    }
                }
            };

            await mediator.Send(new CreateCartCommand(createRequest));
            break;

        case "2":
            Console.Write("Enter Cart Id: ");
            var getId = long.Parse(Console.ReadLine()!);

            await mediator.Send(new GetCartQuery(getId));
            break;

        case "3":
            Console.Write("Enter Cart Id: ");
            var updateId = long.Parse(Console.ReadLine()!);

            var updateRequest = new UpdateCartRequest
            {
                DeviceId = Guid.NewGuid().ToString()
            };

            await mediator.Send(new UpdateCartCommand(updateId, updateRequest));
            break;

        case "4":
            Console.Write("Enter Cart Id: ");
            var deleteId = long.Parse(Console.ReadLine()!);

            await mediator.Send(new DeleteCartCommand(deleteId));
            break;

        case "5":
            await mediator.Send(new GetCartsQuery());
            break;
        
        case "6":
            await mediator.Send(new GetCancelledCartsQuery());
            break;
        
        case "7":
            await mediator.Send(new GetCompletedCartsQuery());
            break;
        
        case "8":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
