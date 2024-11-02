using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class CurrentUser
{
    public static User? CurrUser { get; set; }
}