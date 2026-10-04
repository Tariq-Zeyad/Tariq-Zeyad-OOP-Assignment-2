using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedC_Part2
{
    public class Calculator
    {
        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        public static int Max(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}