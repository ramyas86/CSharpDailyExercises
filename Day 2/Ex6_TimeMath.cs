using System;

class TimeMath
{
    static void Main()
    {
        Console.WriteLine("Welcome to TimeMath!");

        // Prompt for input
        Console.Write("Enter the time in hh:mm format: ");
        string inputTime = Console.ReadLine();

        // Parse the input time
        if (!ParseTime(inputTime, out int hours, out int minutes))
        {
            Console.WriteLine("Invalid time format. Please enter time in hh:mm format.");
            return;
        }

        // Prompt for minutes to add
        Console.Write("Enter the number of minutes to add: ");
        if (!int.TryParse(Console.ReadLine(), out int minutesToAdd) || minutesToAdd < 0)
        {
            Console.WriteLine("Invalid input for minutes. Please enter a valid positive integer.");
            return;
        }

        // Calculate the new time
        int totalMinutes = hours * 60 + minutes;
        int newTotalMinutes = totalMinutes + minutesToAdd;

        int newHours = newTotalMinutes / 60;
        int newMinutes = newTotalMinutes % 60;

        // Format and display the new time
        Console.WriteLine($"Original Time: {FormatTime(hours, minutes)}");
        Console.WriteLine($"Added {minutesToAdd} minutes: {FormatTime(newHours, newMinutes)}");
    }

    // Helper method to parse the time input
    static bool ParseTime(string input, out int hours, out int minutes)
    {
        hours = 0;
        minutes = 0;

        string[] parts = input.Split(':');
        if (parts.Length != 2)
            return false;

        if (!int.TryParse(parts[0], out hours) || hours < 0 || hours >= 24)
            return false;

        if (!int.TryParse(parts[1], out minutes) || minutes < 0 || minutes >= 60)
            return false;

        return true;
    }

    // Helper method to format the time as hh:mm
    static string FormatTime(int hours, int minutes)
    {
        return $"{hours:D2}:{minutes:D2}";
    }
}
