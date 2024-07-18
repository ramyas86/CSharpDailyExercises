using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    // Constructor to initialize properties
    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    // Method to display person details
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {Gender}");
    }
}
