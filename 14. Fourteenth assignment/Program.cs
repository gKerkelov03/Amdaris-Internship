
var blackCoffeeBuilder = new CoffeeBuilder();
var cappuccinoBuilder = new CoffeeBuilder();
var flatWhiteBuilder = new CoffeeBuilder();

blackCoffeeBuilder
    .WithCoffee(CoffeeType.BlackCoffee)
    .WithMilk(MilkType.None)
    .WithSugar(3)
    .AddAdditionalMilk(MilkType.Regular);

cappuccinoBuilder
    .WithCoffee(CoffeeType.Cappuccino)
    .WithMilk(MilkType.Oat)
    .WithSugar(1)
    .AddAdditionalMilk(MilkType.Regular)
    .AddAdditionalMilk(MilkType.Regular)
    .AddAdditionalMilk(MilkType.Soy)
    .AddAdditionalMilk(MilkType.Soy);

flatWhiteBuilder
    .WithCoffee(CoffeeType.FlatWhite)
    .WithMilk(MilkType.Soy);

var blackCoffee = blackCoffeeBuilder.Build();
var cappuccino = cappuccinoBuilder.Build();
var flatWhite = flatWhiteBuilder.Build();

PrintCoffee(blackCoffee);
PrintCoffee(cappuccino);
PrintCoffee(flatWhite);

void PrintCoffee(Coffee coffee)
{
    Console.WriteLine($"Coffee: {coffee.CoffeeType}");

    if (coffee.MilkType != MilkType.None)
    {
        Console.WriteLine($"With milk: {coffee.MilkType}");
    }

    if (coffee.SugarsCount > 0)
    {
        Console.WriteLine($"With {coffee.SugarsCount} sugar{(coffee.SugarsCount > 1 ? "s" : "")}");
    }

    if (coffee.AdditionalMilks.Count > 0)
    {
        Console.WriteLine($"And a number of additional milks: ");
        foreach (var kvp in coffee.AdditionalMilks)
        {
            Console.WriteLine($"    {kvp.Value} {kvp.Key} milk");
        }
    }

    Console.WriteLine();
}