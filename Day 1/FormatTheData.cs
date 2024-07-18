string name = "Zachary";
DateTime bday = new DateTime(1990, 5, 20);
decimal pay = 69759.25m;

Console.WriteLine(
   "V1- {0} was born on {1:dd-MM-yyyy} and earns {2:C}",
   name, bday, pay);

Console.WriteLine(
   $"V2- {name} was born on {bday:dd-MM-yyyy} and earns {pay:C}");
 