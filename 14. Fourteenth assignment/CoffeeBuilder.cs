
public class CoffeeBuilder :
    ICoffeeSelectionStage,
    IMilkSelectionStage,
    ISugarSelectionStage,
    IAdditionalMilkSelectionStage
{
    private Coffee _coffee = new Coffee();

    public IMilkSelectionStage WithCoffee(CoffeeType coffee)
    {
        _coffee.CoffeeType = coffee;
        return this;
    }

    public ISugarSelectionStage WithMilk(MilkType milk)
    {
        var milkChosen = milk;

        if (milkChosen != MilkType.None && _coffee.CoffeeType == CoffeeType.BlackCoffee)
        {
            throw new ArgumentException("Black coffee cannot have milk");
        }

        _coffee.MilkType = milkChosen;
        return this;
    }

    public IAdditionalMilkSelectionStage WithSugar(int sugarCount)
    {
        _coffee.SugarsCount = sugarCount;
        return this;
    }

    public IAdditionalMilkSelectionStage AddAdditionalMilk(MilkType milk)
    {
        if (!_coffee.AdditionalMilks.ContainsKey(milk))
        {
            _coffee.AdditionalMilks[milk] = 0;
        }

        _coffee.AdditionalMilks[milk]++;
        return this;
    }

    public Coffee Build() => _coffee;
}
