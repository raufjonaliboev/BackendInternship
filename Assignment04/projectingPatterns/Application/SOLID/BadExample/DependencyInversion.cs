namespace projectingPatterns.Application.SOLID.BadExample;

public class DependencyInversion
{
    private readonly PaymentService _paymentService = new PaymentService();
    public void Run()
    {
        _paymentService.Pay();
    }
}

public class PaymentService
{
    private readonly StripePayment _stripePayment = new StripePayment();

    public void Pay()
    {
        _stripePayment.ProcessPayment();
    }
}

public class StripePayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Payment processing via Stripe...");
    }
}
