using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQandObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of people
            List<Person> people = new List<Person>
            {
                new Person { Name = "Alice", Gender = "Female", Age = 22, Hometown = "New York" },
                new Person { Name = "Bob", Gender = "Male", Age = 30, Hometown = "Los Angeles" },
                new Person { Name = "Charlie", Gender = "Male", Age = 19, Hometown = "Chicago" },
                new Person { Name = "Diana", Gender = "Female", Age = 28, Hometown = "Houston" },
                new Person { Name = "Eve", Gender = "Female", Age = 24, Hometown = "Phoenix" },
                new Person { Name = "Frank", Gender = "Male", Age = 23, Hometown = "Philadelphia" },
                new Person { Name = "Grace", Gender = "Female", Age = 26, Hometown = "San Antonio" },
                new Person { Name = "Hank", Gender = "Male", Age = 27, Hometown = "San Diego" },
                new Person { Name = "Ivy", Gender = "Female", Age = 21, Hometown = "Dallas" },
                new Person { Name = "Jack", Gender = "Male", Age = 31, Hometown = "San Jose" },
                new Person { Name = "Karen", Gender = "Female", Age = 22, Hometown = "Austin" },
                new Person { Name = "Leo", Gender = "Male", Age = 18, Hometown = "Jacksonville" },
                new Person { Name = "Mia", Gender = "Female", Age = 23, Hometown = "Fort Worth" },
                new Person { Name = "Nina", Gender = "Female", Age = 20, Hometown = "Columbus" },
                new Person { Name = "Oscar", Gender = "Male", Age = 25, Hometown = "Charlotte" },
                new Person { Name = "Paul", Gender = "Male", Age = 24, Hometown = "Indianapolis" },
                new Person { Name = "Quinn", Gender = "Female", Age = 19, Hometown = "San Francisco" },
                new Person { Name = "Rick", Gender = "Male", Age = 29, Hometown = "Seattle" },
                new Person { Name = "Sara", Gender = "Female", Age = 27, Hometown = "Denver" },
                new Person { Name = "Tom", Gender = "Male", Age = 22, Hometown = "Washington" },
            };

            // Display the results for each LINQ query
            DisplayMalesUnder25(people);
            DisplayDistinctHometownsInAscendingOrder(people);
            DisplayPeopleSortedByHometownAndName(people);
            DisplayAverageAgeByGender(people);
            DisplayHometownCounts(people);
        }

        static void DisplayMalesUnder25(List<Person> people)
        {
            var malesUnder25 = people.Where(p => p.Gender == "Male" && p.Age < 25);
            Console.WriteLine("Males under 25:");
            foreach (var person in malesUnder25)
            {
                Console.WriteLine($"{person.Name} from {person.Hometown}, Age: {person.Age}");
            }
        }

        static void DisplayDistinctHometownsInAscendingOrder(List<Person> people)
        {
            var distinctHometowns = people.Select(p => p.Hometown).Distinct().OrderBy(h => h);
            Console.WriteLine("Distinct hometowns in ascending order:");
            foreach (var hometown in distinctHometowns)
            {
                Console.WriteLine(hometown);
            }
        }

        static void DisplayPeopleSortedByHometownAndName(List<Person> people)
        {
            var sortedPeople = people.OrderBy(p => p.Hometown).ThenBy(p => p.Name);
            Console.WriteLine("People sorted by hometown, then by name:");
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} from {person.Hometown}, Age: {person.Age}");
            }
        }

        static void DisplayAverageAgeByGender(List<Person> people)
        {
            var averageAgeWomen = people.Where(p => p.Gender == "Female").Average(p => p.Age);
            var averageAgeMen = people.Where(p => p.Gender == "Male").Average(p => p.Age);

            Console.WriteLine($"Average age of all women: {averageAgeWomen:F2}");
            Console.WriteLine($"Average age of all men: {averageAgeMen:F2}");
        }

        static void DisplayHometownCounts(List<Person> people)
        {
            var hometownCounts = people.GroupBy(p => p.Hometown)
                                       .Select(g => new { Hometown = g.Key, Count = g.Count() })
                                       .OrderBy(h => h.Hometown);

            Console.WriteLine("Hometown counts:");
            foreach (var item in hometownCounts)
            {
                Console.WriteLine($"{item.Hometown}: {item.Count}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
