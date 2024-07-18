using System;

class ProcessTestScores
{
    public static void Main()
    {
        // Call GetTestScores method to read test scores
        int[] testScores = GetTestScores();

        // Call GetHighestScore method to find the highest test score
        int highestScore = GetHighestScore(testScores);

        // Call GetLowestScore method to find the lowest test score
        int lowestScore = GetLowestScore(testScores);

        // Call GetAverageScore method to calculate the average test score
        double averageScore = GetAverageScore(testScores);

        // Display results
        Console.WriteLine($"Highest Score: {highestScore}");
        Console.WriteLine($"Lowest Score: {lowestScore}");
        Console.WriteLine($"Average Score: {averageScore:F2}");
    }

    // Method to read and return an array of 6 test scores
    static int[] GetTestScores()
    {
        int[] scores = new int[6];

        Console.WriteLine("Enter 6 test scores:");

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Score {i + 1}: ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        return scores;
    }

    // Method to find and return the highest test score
    static int GetHighestScore(int[] scores)
    {
        int highest = scores[0];

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] > highest)
            {
                highest = scores[i];
            }
        }

        return highest;
    }

    // Method to find and return the lowest test score
    static int GetLowestScore(int[] scores)
    {
        int lowest = scores[0];

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] < lowest)
            {
                lowest = scores[i];
            }
        }

        return lowest;
    }

    // Method to calculate and return the average test score
    static double GetAverageScore(int[] scores)
    {
        int sum = 0;

        foreach (int score in scores)
        {
            sum += score;
        }

        double average = (double)sum / scores.Length;
        return average;
    }
}
