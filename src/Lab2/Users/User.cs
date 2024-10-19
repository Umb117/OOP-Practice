namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    private static int _globalId;
    private int id;

    public string Name { get; }

    public User(string name)
    {
        id = _globalId++;
        Name = name;
        IncrementId();
    }

    private static void IncrementId()
    {
        _globalId++;
    }
}