using System;

class NameAndAge
{
    static void Main()
    {
        string answer;
        do
        {
            // Prompt the user for name and age on 31-December
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("How old will you be on 31-December?");
            int ageOnDecember31 = Convert.ToInt32(Console.ReadLine());

            // Call GetBirthYear method to calculate birth year
            int birthYear = GetBirthYear(ageOnDecember31);

            // Display the result
            Console.WriteLine($"{name} was born in {birthYear}");

            // Prompt user to enter another
            Console.WriteLine("Do you want to enter another (yes/no)?");
            answer = Console.ReadLine();
        } while (answer.Equals("yes", StringComparison.OrdinalIgnoreCase));
    }

    // Method to calculate birth year based on age on 31-December
    static int GetBirthYear(int ageOnDecember31)
    {
        // Get current year
        int currentYear = DateTime.Today.Year;

        // Calculate birth year
        int birthYear = currentYear - ageOnDecember31;

        return birthYear;
    }
}
