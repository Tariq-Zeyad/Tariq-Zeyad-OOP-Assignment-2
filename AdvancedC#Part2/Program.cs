using System;

namespace AdvancedC_Part2
{
    internal class Program
    {
        public static decimal RegularDiscount(decimal price) => price;
        public static decimal StudentDiscount(decimal price) => price * 0.80m;
        public static decimal WeekendDiscount(decimal price) => price * 0.90m;

        static void Main(string[] args)
        {
            // First Task
            OpreationsDeleagate divideOp = Calculator.Divide;
            OpreationsDeleagate maxOp = Calculator.Max;

           
            int divideResult = divideOp(20, 4);       
            int maxResult = maxOp.Invoke(20, 4);      // Calling delegate explicitly with .Invoke()

            Console.WriteLine($"Divide(20, 4) -> {divideResult}");
            Console.WriteLine($"Max(20, 4)    -> {maxResult}");

            //----------------------------------------------

            // Second Task
            decimal price = 100m;

            // 1. Regular Checkout 
            decimal regularPrice = CheckoutManager.Checkout(price, RegularDiscount);

            // 2. Student Checkout 
            decimal studentPrice = CheckoutManager.Checkout(price, StudentDiscount);

            // 3. Weekend Checkout 
            decimal weekendPrice = CheckoutManager.Checkout(price, WeekendDiscount);

            Console.WriteLine($"Regular: {regularPrice}");
            Console.WriteLine($"Student: {studentPrice}");
            Console.WriteLine($"Weekend: {weekendPrice}");
        }
    }
}