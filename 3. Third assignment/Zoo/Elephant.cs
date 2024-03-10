namespace Zoo;

public class Elephant : Animal
{
    public Elephant(string name, int age)
        : base(name, age) { }

    public override void MakeSound()
        => Console.WriteLine("Elephant sound!");

    public override object Clone()
        => new Elephant(this.Name, this.Age);

}