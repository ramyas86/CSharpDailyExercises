using System;
using System.Collections.Generic;
using System.Linq;

class FavoriteMovies
{
    private List<string> movies = new List<string>();

    public void Run()
    {
        Console.WriteLine("Welcome to Favorite Movies App!");

        // Loop to allow adding multiple movies
        do
        {
            Console.WriteLine("\nEnter a movie name (or 'q' to quit adding movies):");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "q")
                break;

            AddMovie(input);

        } while (true);

        // Sort the list of movies alphabetically
        movies.Sort();

        // Show sorted list
        Console.WriteLine("\nYour favorite movies (sorted):");
        DisplayMovies();

        // Loop for searching movies
        do
        {
            Console.WriteLine("\nSearch movies:");
            Console.WriteLine("1. Partial Search");
            Console.WriteLine("2. Exact Search");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter a word or phrase to search (partial match): ");
                    string partialSearch = Console.ReadLine().Trim().ToLower();
                    PerformPartialSearch(partialSearch);
                    break;
                case "2":
                    Console.Write("\nEnter the exact movie name to search: ");
                    string exactSearch = Console.ReadLine().Trim().ToLower();
                    PerformExactSearch(exactSearch);
                    break;
                case "3":
                    Console.WriteLine("\nExiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }

        } while (true);
    }

    // Method to add a movie to the list
    private void AddMovie(string movie)
    {
        movies.Add(movie);
        Console.WriteLine($"Added '{movie}' to your favorite movies.");
    }

    // Method to display all movies in the list
    private void DisplayMovies()
    {
        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }

    // Method to perform partial search
    private void PerformPartialSearch(string searchTerm)
    {
        var results = movies.Where(m => m.ToLower().Contains(searchTerm)).ToList();

        Console.WriteLine($"\nMovies containing '{searchTerm}':");

        if (results.Any())
        {
            foreach (var movie in results)
            {
                Console.WriteLine(movie);
            }
        }
        else
        {
            Console.WriteLine("No movies found.");
        }
    }

    // Method to perform exact search
    private void PerformExactSearch(string searchTerm)
    {
        bool found = movies.Exists(m => m.ToLower() == searchTerm);

        if (found)
        {
            Console.WriteLine($"\n'{searchTerm}' was found in your favorite movies.");
        }
        else
        {
            Console.WriteLine($"\n'{searchTerm}' was not found in your favorite movies.");
        }
    }
}

class Program
{
    static void Main()
    {
        FavoriteMovies app = new FavoriteMovies();
        app.Run();
    }
}
