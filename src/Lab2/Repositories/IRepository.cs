namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T> where T : class
{
    public void AddEntity(int id, T entity);

    public T? FindEntity(int id);
}