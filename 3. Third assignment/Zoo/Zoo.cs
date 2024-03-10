using System.Collections;

namespace Zoo;

public class Zoo : IEnumerable<Animal>
{
    private IList<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
        => animals.Add(animal);

    public IEnumerator<Animal> GetEnumerator()
        => animals.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}