
namespace Zoo;

public class Lion : Animal
{
    public Lion(string name, int age)
        : base(name, age) { }

    public override void MakeSound()
        => Console.WriteLine("Roar!");

    //Just so we have an overloaded method and pass all the requirements
    public void MakeSound(string specificSound)
        => Console.WriteLine(specificSound);

    public override object Clone()
        => new Lion(this.Name, this.Age);
}