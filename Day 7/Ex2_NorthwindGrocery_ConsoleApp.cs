using System;
using System.Data.SqlClient;

namespace NorthwindGrocery_ConsoleApp
{
    class Program
    {
        static string connectionString = "Server=WSAMZN-ASEPCTJ2;Database=demo;User Id=sa;Password=Password@123;\r\n";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Northwind Grocery Console App");
                Console.WriteLine("1 - List all categories");
                Console.WriteLine("2 - List products in a specific category");
                Console.WriteLine("3 - List products in a price range");
                Console.WriteLine("4 - List all suppliers");
                Console.WriteLine("5 - List products from a specific supplier");
                Console.WriteLine("6 - Quit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListCategories();
                        break;
                    case "2":
                        ListProductsByCategory();
                        break;
                    case "3":
                        ListProductsByPriceRange();
                        break;
                    case "4":
                        ListSuppliers();
                        break;
                    case "5":
                        ListProductsBySupplier();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ListCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName FROM Categories";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Categories:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CategoryID"]} - {reader["CategoryName"]}");
                }
            }
        }

        static void ListProductsByCategory()
        {
            Console.Write("Enter the category name: ");
            string categoryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT p.ProductID, p.ProductName 
                    FROM Products p
                    JOIN Categories c ON p.CategoryID = c.CategoryID
                    WHERE c.CategoryName = @CategoryName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products in category '{categoryName}':");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]} - {reader["ProductName"]}");
                }
            }
        }

        static void ListProductsByPriceRange()
        {
            Console.Write("Enter the minimum price: ");
            decimal minPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the maximum price: ");
            decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT ProductID, ProductName 
                    FROM Products
                    WHERE UnitPrice BETWEEN @MinPrice AND @MaxPrice";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);

                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products in the price range {minPrice:C} - {maxPrice:C}:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]} - {reader["ProductName"]}");
                }
            }
        }

        static void ListSuppliers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT SupplierID, CompanyName FROM Suppliers ORDER BY SupplierID";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Suppliers:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["SupplierID"]} - {reader["CompanyName"]}");
                }
            }
        }

        static void ListProductsBySupplier()
        {
            Console.Write("Enter the supplier ID: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT p.ProductID, p.ProductName 
                    FROM Products p
                    WHERE p.SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products from supplier ID {supplierId}:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]} - {reader["ProductName"]}");
                }
            }
        }
    }
}
