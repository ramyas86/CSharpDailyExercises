public enum FoodType
{
    Dry,
    Wet
}

public class FoodItem : InventoryItem
{
    public string Brand { get; set; }
    public FoodType FoodType { get; set; }
    public string AnimalType { get; set; } // e.g., Dog, Cat, etc.
}