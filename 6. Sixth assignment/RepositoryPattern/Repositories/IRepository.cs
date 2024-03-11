
using RepositoryPattern.Entities;

namespace RepositoryPattern.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    void Add(T entity);

    T GetById(Guid id);

    void Update(T entity);

    void Remove(T entity);

    void RemoveById(Guid id);

    void ForEach(Action<T> action);
}