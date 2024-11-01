namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly Dictionary<int, T> _repo = [];

    public void AddEntity(int id, T entity)
    {
        _repo[id] = entity;
    }

    public T? FindEntity(int id)
    {
        return _repo[id] ?? null;
    }
}
