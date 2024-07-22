using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    static List<InventoryItem> inventory = new List<InventoryItem>();
    static string filePath = @"D:\Users\ramya\Workspace\CSharpDaily\CSharpDaily\inventory.txt"; 

    public static void Main()
    {
        inventory = InventoryLoader.LoadInventory(filePath);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nPet Store Inventory Management");
            Console.WriteLine("1 - Show all items");
            Console.WriteLine("2 - Show an item's details");
            Console.WriteLine("3 - Add a new item");
            Console.WriteLine("4 - Purchase an item");
            Console.WriteLine("5 - Search items by name");
            Console.WriteLine("6 - Show low stock items");
            Console.WriteLine("7 - Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllItems();
                    break;
                case "2":
                    ShowItemDetails();
                    break;
                case "3":
                    AddNewItem();
                    break;
                case "4":
                    PurchaseItem();
                    break;
                case "5":
                    SearchItemsByName();
                    break;
                case "6":
                    ShowLowStockItems();
                    break;
                case "7":
                    running = false;
                    SaveInventory(filePath);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void ShowAllItems()
    {
        Console.WriteLine("\nAll Inventory Items:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Type: {item.GetType().Name}");
        }
    }

    public static void ShowItemDetails()
    {
        Console.Write("Enter the ID of the item: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var item = inventory.Find(i => i.Id == id);
            if (item != null)
            {
                Console.WriteLine($"\nID: {item.Id}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Quantity: {item.Quantity}");

                if (item is FoodItem foodItem)
                {
                    Console.WriteLine($"Brand: {foodItem.Brand}");
                    Console.WriteLine($"Food Type(Dry or Wet): {foodItem.FoodType}");
                    Console.WriteLine($"Animal Type: {foodItem.AnimalType}");
                }
                else if (item is AccessoryItem accessoryItem)
                {
                    Console.WriteLine($"Size(small or medium or large): {accessoryItem.Size}");
                    Console.WriteLine($"Color: {accessoryItem.Color}");
                }
                else if (item is CageItem cageItem)
                {
                    Console.WriteLine($"Dimensions(ex: 12x12x12): {cageItem.Dimensions}");
                    Console.WriteLine($"Material(metal or plastic): {cageItem.Material}");
                }
                else if (item is AquariumItem aquariumItem)
                {
                    Console.WriteLine($"Capacity: {aquariumItem.Capacity} gallons");
                    Console.WriteLine($"Shape(Rectangular, Circular): {aquariumItem.Shape}");
                }
                else if (item is ToyItem toyItem)
                {
                    Console.WriteLine($"Material(rubber or plastic): {toyItem.Material}");
                    Console.WriteLine($"Recommended Age: {toyItem.RecommendedAge}");
                }
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    public static void AddNewItem()
    {
        Console.WriteLine("\nAdd a New Item:");
        Console.WriteLine("Choose the type of item:");
        Console.WriteLine("1 - Food");
        Console.WriteLine("2 - Accessory");
        Console.WriteLine("3 - Cage");
        Console.WriteLine("4 - Aquarium");
        Console.WriteLine("5 - Toy");
        Console.Write("Choose an option: ");
        string typeChoice = Console.ReadLine();

        InventoryItem newItem = null;

        switch (typeChoice)
        {
            case "1":
                newItem = new FoodItem();
                FillBasicDetails(newItem);
                Console.Write("Brand: ");
                ((FoodItem)newItem).Brand = Console.ReadLine();
                Console.Write("Food Type (Dry/Wet): ");
                ((FoodItem)newItem).FoodType = (FoodType)Enum.Parse(typeof(FoodType), Console.ReadLine(), true);
                Console.Write("Animal Type: ");
                ((FoodItem)newItem).AnimalType = Console.ReadLine();
                break;
            case "2":
                newItem = new AccessoryItem();
                FillBasicDetails(newItem);
                Console.Write("Size: ");
                ((AccessoryItem)newItem).Size = Console.ReadLine();
                Console.Write("Color: ");
                ((AccessoryItem)newItem).Color = Console.ReadLine();
                break;
            case "3":
                newItem = new CageItem();
                FillBasicDetails(newItem);
                Console.Write("Dimensions: ");
                ((CageItem)newItem).Dimensions = Console.ReadLine();
                Console.Write("Material: ");
                ((CageItem)newItem).Material = Console.ReadLine();
                break;
            case "4":
                newItem = new AquariumItem();
                FillBasicDetails(newItem);
                Console.Write("Capacity (gallons): ");
                ((AquariumItem)newItem).Capacity = int.Parse(Console.ReadLine());
                Console.Write("Shape: ");
                ((AquariumItem)newItem).Shape = Console.ReadLine();
                break;
            case "5":
                newItem = new ToyItem();
                FillBasicDetails(newItem);
                Console.Write("Material: ");
                ((ToyItem)newItem).Material = Console.ReadLine();
                Console.Write("Recommended Age: ");
                ((ToyItem)newItem).RecommendedAge = int.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        inventory.Add(newItem);
        Console.WriteLine("Item added successfully.");
    }

    public static void FillBasicDetails(InventoryItem item)
    {
        Console.Write("ID: ");
        item.Id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        item.Name = Console.ReadLine();
        Console.Write("Description: ");
        item.Description = Console.ReadLine();
        Console.Write("Price: ");
        item.Price = decimal.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        item.Quantity = int.Parse(Console.ReadLine());
    }

    public static void PurchaseItem()
    {
        Console.Write("Enter the ID of the item to purchase: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var item = inventory.Find(i => i.Id == id);
            if (item != null)
            {
                if (item.Quantity > 0)
                {
                    item.Quantity -= 1;
                    Console.WriteLine($"Purchased {item.Name} for {item.Price:C}. Quantity remaining: {item.Quantity}");
                }
                else
                {
                    Console.WriteLine("Item is out of stock.");
                }
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    public static void SearchItemsByName()
    {
        Console.Write("Enter the name of the item to search for: ");
        string searchName = Console.ReadLine().ToLower();
        var foundItems = inventory.FindAll(i => i.Name.ToLower().Contains(searchName));

        if (foundItems.Count > 0)
        {
            Console.WriteLine("\nSearch Results:");
            foreach (var item in foundItems)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Type: {item.GetType().Name}");
            }
        }
        else
        {
            Console.WriteLine("No items found with the specified name.");
        }
    }

    public static void ShowLowStockItems()
    {
        Console.WriteLine("\nLow Stock Items:");
        foreach (var item in inventory)
        {
            if (item.Quantity < 5)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
            }
        }
    }

    public static void SaveInventory(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var item in inventory)
            {
                string itemData = item switch
                {
                    FoodItem foodItem => $"{item.Id},Food,{item.Name},{item.Description},{item.Price},{item.Quantity},{foodItem.Brand},{foodItem.FoodType},{foodItem.AnimalType}",
                    AccessoryItem accessoryItem => $"{item.Id},Accessory,{item.Name},{item.Description},{item.Price},{item.Quantity},{accessoryItem.Size},{accessoryItem.Color}",
                    CageItem cageItem => $"{item.Id},Cage,{item.Name},{item.Description},{item.Price},{item.Quantity},{cageItem.Dimensions},{cageItem.Material}",
                    AquariumItem aquariumItem => $"{item.Id},Aquarium,{item.Name},{item.Description},{item.Price},{item.Quantity},{aquariumItem.Capacity},{aquariumItem.Shape}",
                    ToyItem toyItem => $"{item.Id},Toy,{item.Name},{item.Description},{item.Price},{item.Quantity},{toyItem.Material},{toyItem.RecommendedAge}",
                    _ => $"{item.Id},Unknown,{item.Name},{item.Description},{item.Price},{item.Quantity}"
                };
                sw.WriteLine(itemData);
                Console.WriteLine(itemData);
            }
        }
    }
}
