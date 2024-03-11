
using RepositoryPattern.Entities;

namespace RepositoryPattern.Repositories;

public class WorkersRepository : IRepository<Worker>
{
    private List<Worker> db = new List<Worker>();

    public void Add(Worker entity) 
        => db.Add(entity);

    public Worker GetById(Guid id)
        => db.FirstOrDefault(worker => worker.Id == id);

    public void Remove(Worker entity) 
        => this.db.Remove(entity);

    public void RemoveById(Guid id)
        => this.db.Remove(this.GetById(id));

    public void Update(Worker entity) 
    {
        var index = this.db.FindIndex(worker => worker.Id == entity.Id);

        if(index != -1 )
        {
            this.db[index] = entity;
        }
    }

    public void ForEach(Action<Worker> action) 
        => this.db.ForEach(action);
}