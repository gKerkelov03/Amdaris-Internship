public class Coffee
{
    public CoffeeType CoffeeType { get; set; }

    public MilkType MilkType { get; set; }

    public Dictionary<MilkType, int> AdditionalMilks { get; set; } = new();

    public int SugarsCount { get; set; }
}
