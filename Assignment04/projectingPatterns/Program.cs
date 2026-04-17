using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Application.Patterns;
using projectingPatterns.Application.Products.Commands;
using projectingPatterns.Application.Products.Queries;
using projectingPatterns.Application.SOLID.BadExample;
using projectingPatterns.Application.SOLID.ImprovedExample;
using projectingPatterns.Domain.Entities;
using projectingPatterns.Infrastructure.Data;
using projectingPatterns.Infrastructure.Repositories;
using projectingPatterns.Infrastructure.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPaymentProvider, PayPal>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddKeyedScoped<IDiscountStrategy, GoldDiscountStrategy>("gold");
builder.Services.AddKeyedScoped<IDiscountStrategy, SilverDiscountStrategy>("silver");
builder.Services.AddKeyedScoped<IDiscountStrategy, PlatinumDiscountStrategy>("platinum");
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(projectingPatterns.Application.AssemblyReference).Assembly);
}); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapPost("/products", async ([FromBody] Product product, [FromServices] ISender sender) =>
{
    var result = await sender.Send(new CreateProductCommand(product));
    return Results.Ok(result);
});

app.MapGet("/products", async ([FromServices] ISender sender) =>
{
    var result = await sender.Send(new GetProductsQuery());
    return Results.Ok(result);
});

app.MapGet("/products/{id}", async ([FromRoute] long id, [FromServices] ISender sender) =>
{
    var result = await sender.Send(new GetProductQuery(id));
    return Results.Ok(result);
});

app.MapPut("/products/{id}", async ([FromRoute] long id, [FromBody] Product product, [FromServices] ISender sender) =>
{
    var result = await sender.Send(new UpdateProductCommand(product.Id, product));
});

app.MapDelete("/products/{id}", async ([FromRoute] long id, [FromServices] ISender sender) =>
{
    var result = await sender.Send(new DeleteProductCommand(id));
    return Results.Ok(result);
});

app.MapGet("/factory", () =>
{
    Factory factory = new Factory();
    factory.Run();
});

app.MapGet("/strategy", () =>
{
    Strategy strategy = new Strategy();
    strategy.Run();
});

app.MapGet("/Decorator", () =>
{
   Decorator decorator = new Decorator();
   decorator.Run();
});

app.MapGet("/builder", () =>
{
   Builder b = new Builder();
   b.Run();
});

app.MapGet("/solid-bad-examples", () =>
{
    SolidBadExamples solidBadExamples = new SolidBadExamples();
    solidBadExamples.Run();
});

app.MapGet("/solid-good-examples", () =>
{
    SolidImprovedExamples solidImprovedExamples = new SolidImprovedExamples();
    solidImprovedExamples.Run();
});

app.MapPost("/orders/place", (PlaceOrderRequest request, IServiceProvider sp) =>
{
    var strategy = sp.GetRequiredKeyedService<IDiscountStrategy>(
        request.CustomerTier.ToLower()
    );

    var orderService = new OrderService(
        sp.GetRequiredService<IOrderRepository>(),
        sp.GetRequiredService<INotificationService>(),
        sp.GetRequiredService<IPaymentProvider>(),
        sp.GetRequiredService<IPromotionService>(),
        strategy  
    );

    orderService.PlaceOrder(request.Price);

    return Results.Ok(new 
    { 
        message = "Order placed successfully!",
        tier    = request.CustomerTier,
        price   = request.Price
    });
});

app.Run();

public record PlaceOrderRequest(double Price, string CustomerTier);

