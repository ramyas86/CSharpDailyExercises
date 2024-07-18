using System;

class SportsPlayer
{
    // Properties
    public string PlayerName { get; set; }
    public string Sport { get; set; }
    public int YearsExperience { get; set; }
    public string Team { get; set; }
    public bool IsProfessional { get; set; }

    // Constructor
    public SportsPlayer(string playerName, string sport, int yearsExperience, string team, bool isProfessional)
    {
        PlayerName = playerName;
        Sport = sport;
        YearsExperience = yearsExperience;
        Team = team;
        IsProfessional = isProfessional;
    }

    // Method to print information about the sports player
    public void PrintPlayerInfo()
    {
        Console.WriteLine($"Player Name: {PlayerName}");
        Console.WriteLine($"Sport: {Sport}");
        Console.WriteLine($"Years of Experience: {YearsExperience}");
        Console.WriteLine($"Team: {Team}");
        Console.WriteLine($"Professional Player: {(IsProfessional ? "Yes" : "No")}");
        Console.WriteLine();
    }

    // Another method example (can be added based on specific requirements)
    public void Practice()
    {
        Console.WriteLine($"{PlayerName} is practicing for the upcoming match.");
        Console.WriteLine();
    }
}
