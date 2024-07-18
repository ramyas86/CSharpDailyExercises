// Prompting for integers
Console.WriteLine("Enter the first integer:");
string firstIntInput = Console.ReadLine();
int firstInt = Convert.ToInt32(firstIntInput);

Console.WriteLine("Enter the second integer:");
string secondIntInput = Console.ReadLine();
int secondInt = Convert.ToInt32(secondIntInput);

// Calculating and displaying results for integers
Console.WriteLine("\nResults for integers:");
Console.WriteLine($"Sum: {firstInt + secondInt}");
Console.WriteLine($"Difference: {firstInt - secondInt}");
Console.WriteLine($"Product: {firstInt * secondInt}");
if (secondInt != 0)
{
    Console.WriteLine($"Quotient: {firstInt / secondInt}");
}
else
{
    Console.WriteLine("Quotient: Division by zero is not allowed");
}

// Prompting for doubles
Console.WriteLine("\nEnter the first double:");
string firstDoubleInput = Console.ReadLine();
double firstDouble = Convert.ToDouble(firstDoubleInput);

Console.WriteLine("Enter the second double:");
string secondDoubleInput = Console.ReadLine();
double secondDouble = Convert.ToDouble(secondDoubleInput);

// Calculating and displaying results for doubles
Console.WriteLine("\nResults for doubles:");
Console.WriteLine($"Sum: {firstDouble + secondDouble}");
Console.WriteLine($"Difference: {firstDouble - secondDouble}");
Console.WriteLine($"Product: {firstDouble * secondDouble}");
if (secondDouble != 0)
{
    Console.WriteLine($"Quotient: {firstDouble / secondDouble}");
}
else
{
    Console.WriteLine("Quotient: Division by zero is not allowed");
}