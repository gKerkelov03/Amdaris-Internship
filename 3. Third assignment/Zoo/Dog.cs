
namespace Zoo;

public class Dog : Animal
{
    public Dog(string name, int age)
        : base(name, age) { }

    public override void MakeSound()
        => Console.WriteLine("Bau bau!");

    public override object Clone()
        => new Dog(this.Name, this.Age);
}