using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQandStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of fruits and vegetables
            List<string> fruitsAndVegetables = new List<string>
            {
                "Apple", "Banana", "Strawberry", "Cherry", "Mango", "Blueberry",
                "Kiwi", "Grapefruit", "Pineapple", "Peach", "Apricot", "Blackberry",
                "Cucumber", "Tomato", "Lettuce", "Carrot", "Potato", "Radish",
                "Onion", "Broccoli", "Spinach", "Bell pepper"
            };

            // Display the results for each LINQ query
            DisplayStringsStartingWithB(fruitsAndVegetables);
            DisplayStringsContainingBerry(fruitsAndVegetables);
            DisplayStringsStartingWithAM(fruitsAndVegetables);
            DisplayCountOfStringsStartingWithNZ(fruitsAndVegetables);
            DisplayLongestString(fruitsAndVegetables);
        }

        static void DisplayStringsStartingWithB(List<string> items)
        {
            var result = items.Where(s => s.StartsWith("B") || s.StartsWith("b"));
            Console.WriteLine("Strings that start with B or b:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayStringsContainingBerry(List<string> items)
        {
            var result = items.Where(s => s.Contains("berry", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Strings that contain the word 'berry':");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayStringsStartingWithAM(List<string> items)
        {
            var result = items.Where(s => string.Compare(s, "A", StringComparison.OrdinalIgnoreCase) >= 0
                                       && string.Compare(s, "N", StringComparison.OrdinalIgnoreCase) < 0);
            Console.WriteLine("Strings that start with the letters A-M:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayCountOfStringsStartingWithNZ(List<string> items)
        {
            var count = items.Count(s => string.Compare(s, "N", StringComparison.OrdinalIgnoreCase) >= 0
                                      && string.Compare(s, "Z", StringComparison.OrdinalIgnoreCase) <= 0);
            Console.WriteLine($"Number of strings that start with the letters N-Z: {count}");
        }

        static void DisplayLongestString(List<string> items)
        {
            var longestString = items.OrderByDescending(s => s.Length).FirstOrDefault();
            Console.WriteLine($"The longest string in the list is: {longestString}");
        }
    }
}
