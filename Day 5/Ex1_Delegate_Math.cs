using System;

namespace Delegate_Math
{
    // Delegate declaration
    public delegate double MathOperation(double a, double b);

    // BasicMath class with Add, Subtract, Multiply, and Divide methods
    public class BasicMath
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BasicMath math = new BasicMath();

            // Using delegate to call the Add method
            MathOperation mathOp = new MathOperation(math.Add);
            double result = mathOp(10, 5);
            Console.WriteLine($"Add: 10 + 5 = {result}");

            // Using delegate to call the Subtract method
            mathOp = new MathOperation(math.Subtract);
            result = mathOp(10, 5);
            Console.WriteLine($"Subtract: 10 - 5 = {result}");

            // Using delegate to call the Multiply method
            mathOp = new MathOperation(math.Multiply);
            result = mathOp(10, 5);
            Console.WriteLine($"Multiply: 10 * 5 = {result}");

            // Using delegate to call the Divide method
            mathOp = new MathOperation(math.Divide);
            result = mathOp(10, 5);
            Console.WriteLine($"Divide: 10 / 5 = {result}");

            // Handle division by zero
            try
            {
                result = mathOp(10, 0);
                Console.WriteLine($"Divide: 10 / 0 = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
