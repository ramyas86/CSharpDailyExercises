using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Server=WSAMZN-ASEPCTJ2;Database=Dealership;User Id=sa;Password=Password@123;\r\n";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Dealership Menu:");
            Console.WriteLine("1 - List all available cars");
            Console.WriteLine("2 - List available cars with less than a specific odometer reading");
            Console.WriteLine("3 - List available cars with a specific make and model");
            Console.WriteLine("4 - List available cars between a specific price range");
            Console.WriteLine("5 - Sell a car");
            Console.WriteLine("6 - Change a car’s price");
            Console.WriteLine("7 - Delete a car from inventory");
            Console.WriteLine("8 - Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAvailableCars();
                    break;
                case "2":
                    ListCarsByOdometer();
                    break;
                case "3":
                    ListCarsByMakeAndModel();
                    break;
                case "4":
                    ListCarsByPriceRange();
                    break;
                case "5":
                    SellCar();
                    break;
                case "6":
                    ChangeCarPrice();
                    break;
                case "7":
                    DeleteCar();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private static void ListAvailableCars()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Cars WHERE status = 'available'", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void ListCarsByOdometer()
    {
        Console.Write("Enter the maximum odometer reading: ");
        int maxOdometer = int.Parse(Console.ReadLine());

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Cars WHERE status = 'available' AND odometer_reading <= @maxOdometer", conn);
            cmd.Parameters.AddWithValue("@maxOdometer", maxOdometer);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void ListCarsByMakeAndModel()
    {
        Console.Write("Enter the make: ");
        string make = Console.ReadLine();
        Console.Write("Enter the model: ");
        string model = Console.ReadLine();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Cars WHERE status = 'available' AND make = @make AND model = @model", conn);
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@model", model);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void ListCarsByPriceRange()
    {
        Console.Write("Enter the minimum price: ");
        decimal minPrice = decimal.Parse(Console.ReadLine());
        Console.Write("Enter the maximum price: ");
        decimal maxPrice = decimal.Parse(Console.ReadLine());

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Cars WHERE status = 'available' AND price BETWEEN @minPrice AND @maxPrice", conn);
            cmd.Parameters.AddWithValue("@minPrice", minPrice);
            cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void SellCar()
    {
        Console.Write("Enter the inventory number of the car being sold: ");
        string inventoryNumber = Console.ReadLine();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Fetch car details
            var cmd = new SqlCommand("SELECT * FROM Cars WHERE inventory_number = @inventoryNumber AND status = 'available'", conn);
            cmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
                reader.Close();

                // Get sales data
                Console.Write("Enter the sales date (YYYY-MM-DD): ");
                string salesDate = Console.ReadLine();
                Console.Write("Enter customer name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter customer phone: ");
                string customerPhone = Console.ReadLine();
                Console.Write("Enter payment method: ");
                string paymentMethod = Console.ReadLine();
                Console.Write("Enter payment amount: ");
                decimal paymentAmount = decimal.Parse(Console.ReadLine());

                // Insert sales record
                var salesCmd = new SqlCommand("INSERT INTO Sales (inventory_number, sales_date, customer_name, customer_phone, payment_method, payment_amount) VALUES (@inventoryNumber, @salesDate, @customerName, @customerPhone, @paymentMethod, @paymentAmount)", conn);
                salesCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                salesCmd.Parameters.AddWithValue("@salesDate", salesDate);
                salesCmd.Parameters.AddWithValue("@customerName", customerName);
                salesCmd.Parameters.AddWithValue("@customerPhone", customerPhone);
                salesCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                salesCmd.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                salesCmd.ExecuteNonQuery();

                // Update car status to 'sold'
                var updateCmd = new SqlCommand("UPDATE Cars SET status = 'sold' WHERE inventory_number = @inventoryNumber", conn);
                updateCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                updateCmd.ExecuteNonQuery();

                // Generate receipt
                string receiptContent = $"Receipt for Inventory Number: {inventoryNumber}\nDate of Sale: {salesDate}\nCustomer Name: {customerName}\nCustomer Phone: {customerPhone}\nPayment Method: {paymentMethod}\nPayment Amount: {paymentAmount:C}";
                System.IO.File.WriteAllText($"{inventoryNumber}_receipt.txt", receiptContent);

                Console.WriteLine("Car sold successfully. Receipt generated.");
            }
            else
            {
                Console.WriteLine("Car not found or already sold.");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void ChangeCarPrice()
    {
        Console.Write("Enter the inventory number of the car: ");
        string inventoryNumber = Console.ReadLine();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Cars WHERE inventory_number = @inventoryNumber", conn);
            cmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
                reader.Close();

                Console.Write("Enter the new price: ");
                decimal newPrice = decimal.Parse(Console.ReadLine());

                var updateCmd = new SqlCommand("UPDATE Cars SET price = @newPrice WHERE inventory_number = @inventoryNumber", conn);
                updateCmd.Parameters.AddWithValue("@newPrice", newPrice);
                updateCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                updateCmd.ExecuteNonQuery();

                Console.WriteLine("Car price updated successfully.");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private static void DeleteCar()
    {
        Console.Write("Enter the inventory number of the car to delete: ");
        string inventoryNumber = Console.ReadLine();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Cars WHERE inventory_number = @inventoryNumber", conn);
            cmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Inventory Number: {reader["inventory_number"]}, Make: {reader["make"]}, Model: {reader["model"]}, Price: {reader["price"]}");
                reader.Close();

                Console.Write("Are you sure you want to delete this car? (yes/no): ");
                string confirmation = Console.ReadLine();

                if (confirmation.ToLower() == "yes")
                {
                    var deleteCmd = new SqlCommand("DELETE FROM Cars WHERE inventory_number = @inventoryNumber", conn);
                    deleteCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                    deleteCmd.ExecuteNonQuery();

                    Console.WriteLine("Car deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Car deletion cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
            conn.Close();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
}
