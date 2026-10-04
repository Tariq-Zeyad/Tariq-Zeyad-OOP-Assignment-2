using System;

namespace AdvancedC_Part2
{
    public delegate decimal DiscountStrategy(decimal price);

    public class CheckoutManager
    {
        public static decimal Checkout(decimal price, DiscountStrategy applyDiscount)
        {
            Validate(price);

            decimal final = applyDiscount(price);

            return final * 1.14m;
        }

        private static void Validate(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
        }
    }
}