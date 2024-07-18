using System;

class ClassPlay
{
    static void Main()
    {
        // Create instances of SportsPlayer using the constructor
        SportsPlayer player1 = new SportsPlayer("John Doe", "Basketball", 10, "Team A", true);
        SportsPlayer player2 = new SportsPlayer("Jane Smith", "Soccer", 8, "Team B", true);
        SportsPlayer player3 = new SportsPlayer("Mike Johnson", "Tennis", 15, "Individual", false);

        // Call methods on each instance
        player1.PrintPlayerInfo();
        player1.Practice();

        player2.PrintPlayerInfo();
        player2.Practice();

        player3.PrintPlayerInfo();
        player3.Practice();
    }
}
