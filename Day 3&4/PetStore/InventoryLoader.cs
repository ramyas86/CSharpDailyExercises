using System;
using System.Collections.Generic;
using System.IO;

public static class InventoryLoader
{
    public static List<InventoryItem> LoadInventory(string filePath)
    {
        List<InventoryItem> inventory = new List<InventoryItem>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                int id = int.Parse(data[0]);
                string type = data[1];
                string name = data[2];
                string description = data[3];
                decimal price = decimal.Parse(data[4]);
                int quantity = int.Parse(data[5]);

                InventoryItem item = type switch
                {
                    "Food" => new FoodItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Brand = data[6],
                        FoodType = (FoodType)Enum.Parse(typeof(FoodType), data[7], true),
                        AnimalType = data[8]
                    },
                    "Accessory" => new AccessoryItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Size = data[6],
                        Color = data[7]
                    },
                    "Cage" => new CageItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Dimensions = data[6],
                        Material = data[7]
                    },
                    "Aquarium" => new AquariumItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Capacity = int.Parse(data[6]),
                        Shape = data[7]
                    },
                    "Toy" => new ToyItem
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        Material = data[6],
                        RecommendedAge = int.Parse(data[7])
                    },
                    _ => null
                };

                if (item != null)
                {
                    inventory.Add(item);
                }
            }
        }

        return inventory;
    }
}

