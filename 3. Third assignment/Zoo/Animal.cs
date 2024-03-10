namespace Zoo;

public abstract class Animal : ICloneable
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void MakeSound();

    public abstract object Clone();
}


