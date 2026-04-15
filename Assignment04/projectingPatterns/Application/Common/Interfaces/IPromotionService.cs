using projectingPatterns.Application.SOLID.ImprovedExample;

namespace projectingPatterns.Application.Common.Interfaces;

public interface IPromotionService
{
        public double CalculatePromotion(IDiscountStrategy discountStrategy, double price);
}