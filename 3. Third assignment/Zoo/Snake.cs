
namespace Zoo;

public class Snake : Animal
{
    public Snake(string name, int age)
        : base(name, age) { }

    public override void MakeSound()
        => Console.WriteLine("Ssssss!");

    public override object Clone()
        => new Snake(this.Name, this.Age);
}