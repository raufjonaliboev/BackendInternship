namespace projectingPatterns.Application.SOLID.BadExample;

public class SingleResponsibility
{
    public void Run()
    {
        CartService cartService = new CartService();
        cartService.CreateCart();
        cartService.UpdateCart();
        cartService.SendEmail();
    }
}

public class CartService
{
    public void CreateCart()
    {
        Console.WriteLine("Cart creation logic!");
    }

    public void UpdateCart()
    {
        Console.WriteLine("Cart update logic!");
    }

    public void SendEmail()
    {
        Console.WriteLine("Cart send email logic!");
    }
}