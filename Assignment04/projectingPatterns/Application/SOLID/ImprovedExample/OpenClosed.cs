using projectingPatterns.Application.Common.Interfaces;

namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class OpenClosed
{
    public void Run()
    {
        PromotionService promotionService = new PromotionService();
        double priceForGold = promotionService.CalculatePromotion(new GoldDiscountStrategy(), 100);
        Console.WriteLine($"Price for GOLD customer: {priceForGold}");

        double priceForSilver = promotionService.CalculatePromotion(new SilverDiscountStrategy(), 100);
        Console.WriteLine($"Price for SILVER customer: {priceForSilver}");

        double priceForPlatinum = promotionService.CalculatePromotion(new PlatinumDiscountStrategy(), 100);
        Console.WriteLine($"Price for PLATINUM customer: {priceForPlatinum}");
    }
}

public interface IDiscountStrategy
{
    public double ApplyDiscount(double price);
}

public class GoldDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price * 0.8;
    }
}

public class SilverDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price * 0.9;
    }
}

public class PlatinumDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price * 0.7;
    }
}

public class PromotionService : IPromotionService
{
    public double CalculatePromotion(IDiscountStrategy discountStrategy, double price)
    {
        return discountStrategy.ApplyDiscount(price);
    }
}



