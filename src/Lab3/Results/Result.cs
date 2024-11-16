namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public abstract record Result
{
    public sealed record ReadSuccess : Result { }

    public sealed record NoUnreadMessagesFail : Result { }

    public sealed record ImportanceFail : Result { }
}