using System;

class PriceQuoter
{
    static void Main()
    {
        // Displaying the product code and quantity options
        Console.WriteLine("Available Product Codes:");
        Console.WriteLine("1. BG-127");
        Console.WriteLine("2. WRTR-28");
        Console.WriteLine("3. GUAC-8");

        // Getting user input for product code
        Console.Write("Enter the product code: ");
        string productCode = Console.ReadLine().Trim().ToUpper(); // Convert to uppercase for case insensitivity

        // Getting user input for quantity
        Console.Write("Enter the quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        // Lookup per unit price based on product code and quantity
        double unitPrice = GetUnitPrice(productCode, quantity);

        // Calculate total price
        double totalPrice = unitPrice * quantity;

        // Check if large order discount applies
        bool isLargeOrder = (quantity >= 250);
        double discountedPrice = ApplyDiscount(totalPrice, isLargeOrder);

        // Displaying the results
        Console.WriteLine("\nOrder Summary:");
        Console.WriteLine($"Product Code: {productCode}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Per Unit Price: ${unitPrice:F2}");

        if (isLargeOrder)
        {
            Console.WriteLine($"Large Order Discount Applied (15%): Yes");
            Console.WriteLine($"Total Price (after discount): ${discountedPrice:F2}");
        }
        else
        {
            Console.WriteLine($"Large Order Discount Applied (15%): No");
            Console.WriteLine($"Total Price: ${totalPrice:F2}");
        }
    }

    // Function to retrieve the per unit price based on product code and quantity
    static double GetUnitPrice(string productCode, int quantity)
    {
        switch (productCode)
        {
            case "BG-127":
                if (quantity >= 51)
                    return 14.49;
                else if (quantity >= 25)
                    return 17.00;
                else
                    return 18.99;

            case "WRTR-28":
                if (quantity >= 51)
                    return 99.99;
                else if (quantity >= 25)
                    return 113.75;
                else
                    return 125.00;

            case "GUAC-8":
                if (quantity >= 51)
                    return 7.49;
                else
                    return 8.99;

            default:
                throw new ArgumentException("Invalid product code.");
        }
    }

    // Function to apply additional discount for large orders
    static double ApplyDiscount(double totalPrice, bool isLargeOrder)
    {
        if (isLargeOrder)
        {
            return totalPrice * 0.85; // Apply 15% discount
        }
        else
        {
            return totalPrice;
        }
    }
}
