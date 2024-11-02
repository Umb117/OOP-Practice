namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    private static int _globalId;

    public int Id { get; init; }

    public string Name { get; private set; }

    public User(string name)
    {
        Id = _globalId;
        Name = name;
        _globalId++;
    }
}