using System;

class MortgageCalculator
{
    static void Main()
    {
        Console.WriteLine("How much are you borrowing?");
        double amountBorrowed = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("What is your interest rate?");
        double annualInterestRate = Convert.ToDouble(Console.ReadLine());
        double monthlyInterestRate = annualInterestRate / 1200;

        Console.WriteLine("How long is your loan (in years)?");
        int loanDurationInYears = Convert.ToInt32(Console.ReadLine());
        int numberOfMonthlyPayments = loanDurationInYears * 12;

        double estimatedPayment = CalculateMonthlyPayment(amountBorrowed, monthlyInterestRate, numberOfMonthlyPayments);

        Console.WriteLine($"Your estimated payment is {estimatedPayment:C}");
    }

    static double CalculateMonthlyPayment(double amount, double monthlyInterestRate, int numberOfPayments)
    {
        return amount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));
    }
}
