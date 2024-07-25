using System;
using System.Linq;

namespace LINQandNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate an array with 50 random numbers between 1 and 10,000
            int[] numbers = GenerateRandomNumbers(50, 1, 10000);

            // Display the results for each LINQ query
            DisplayNumbersInAscendingOrder(numbers);
            DisplayNumbersUnder100InDescendingOrder(numbers);
            DisplayEvenNumbersInOriginalOrder(numbers);
            DisplayMinMaxSum(numbers);
        }

        static int[] GenerateRandomNumbers(int count, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(minValue, maxValue + 1);
            }
            return numbers;
        }

        static void DisplayNumbersInAscendingOrder(int[] numbers)
        {
            var sortedNumbers = numbers.OrderBy(n => n);
            Console.WriteLine("Numbers in ascending order:");
            foreach (var number in sortedNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static void DisplayNumbersUnder100InDescendingOrder(int[] numbers)
        {
            var filteredNumbers = numbers.Where(n => n < 100).OrderByDescending(n => n);
            Console.WriteLine("Numbers under 100 in descending order:");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static void DisplayEvenNumbersInOriginalOrder(int[] numbers)
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even numbers in original order:");
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static void DisplayMinMaxSum(int[] numbers)
        {
            int minNumber = numbers.Min();
            int maxNumber = numbers.Max();
            int sum = numbers.Sum();

            Console.WriteLine("Minimum number: " + minNumber);
            Console.WriteLine("Maximum number: " + maxNumber);
            Console.WriteLine("Sum of all numbers: " + sum);
        }
    }
}
