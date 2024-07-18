using System;
using System.Collections.Generic;

class ManagingFamily
{
    private List<Person> familyMembers = new List<Person>();

    public void Run()
    {
        Console.WriteLine("Welcome to Managing Family App!");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a Person");
            Console.WriteLine("2. Display All People");
            Console.WriteLine("3. Display People of a Selected Gender");
            Console.WriteLine("4. Display People Between an Age Range");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    AddPerson();
                    break;
                case "2":
                    DisplayAllPeople();
                    break;
                case "3":
                    DisplayPeopleByGender();
                    break;
                case "4":
                    DisplayPeopleByAgeRange();
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("\nExiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    // Method to add a new person
    private void AddPerson()
    {
        Console.Write("\nEnter the name of the person: ");
        string name = Console.ReadLine().Trim();

        Console.Write("Enter the age of the person: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the gender of the person: ");
        string gender = Console.ReadLine().Trim();

        Person newPerson = new Person(name, age, gender);
        familyMembers.Add(newPerson);

        Console.WriteLine($"Added {name} to the family!");
    }

    // Method to display all people
    private void DisplayAllPeople()
    {
        Console.WriteLine("\nAll Family Members:");
        foreach (var person in familyMembers)
        {
            person.Display();
        }
    }

    // Method to display people of a selected gender
    private void DisplayPeopleByGender()
    {
        Console.Write("\nEnter the gender to filter by (e.g., Male, Female): ");
        string genderFilter = Console.ReadLine().Trim();

        Console.WriteLine($"\nFamily Members of Gender '{genderFilter}':");
        foreach (var person in familyMembers)
        {
            if (person.Gender.Equals(genderFilter, StringComparison.OrdinalIgnoreCase))
            {
                person.Display();
            }
        }
    }

    // Method to display people between an age range
    private void DisplayPeopleByAgeRange()
    {
        Console.Write("\nEnter the minimum age: ");
        int minAge = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the maximum age: ");
        int maxAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nFamily Members between ages {minAge} and {maxAge}:");
        foreach (var person in familyMembers)
        {
            if (person.Age >= minAge && person.Age <= maxAge)
            {
                person.Display();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ManagingFamily app = new ManagingFamily();
        app.Run();
    }
}
