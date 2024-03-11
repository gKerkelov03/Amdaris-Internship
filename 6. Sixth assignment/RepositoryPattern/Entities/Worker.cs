
namespace RepositoryPattern.Entities;

public class Worker : BaseEntity
{
    public Worker(string name, int age, string jobTitle) 
    {
        this.Name = name;
        this.Age = age;
        this.JobTitle = jobTitle;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string JobTitle { get; set; }

}