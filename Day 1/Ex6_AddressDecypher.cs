using System;

class AddressDecypher
{
    static void Main()
    {
        // Define the encoded address
        string encodedAddress = "Betty Smallwood|3329 Duchess|Erath, Texas";

        // Split the encoded address using '|' and '|,' as separators
        string[] fields = encodedAddress.Split(new string[] { "|", "|," }, StringSplitOptions.None);

        // Ensure we have exactly 3 fields
        if (fields.Length != 3)
        {
            Console.WriteLine("Invalid encoded address format.");
            return;
        }

        // Extract individual fields
        string name = fields[0].Trim();
        string address = fields[1].Trim();
        string cityState = fields[2].Trim();

        // Split cityState into city and state
        string[] cityStateParts = cityState.Split(',');
        if (cityStateParts.Length != 2)
        {
            Console.WriteLine("Invalid city, state format.");
            return;
        }

        string city = cityStateParts[0].Trim();
        string state = cityStateParts[1].Trim();

        // Display the extracted fields
        Console.WriteLine("Decyphered Address:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine($"City: {city}");
        Console.WriteLine($"State: {state}");
    }
}
