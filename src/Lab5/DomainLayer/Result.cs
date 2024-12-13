namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;

public abstract record Result
{
    public abstract string Message { get; init; }

    public sealed record Success : Result
    {
        public override string Message { get; init; } = string.Empty;
    }

    public sealed record AccountNotFound : Result
    {
        public override string Message { get; init; }

        public AccountNotFound(string message)
        {
            Message = message;
        }
    }

    public sealed record PasswordWrong : Result
    {
        public override string Message { get; init; }

        public PasswordWrong(string message)
        {
            Message = message;
        }
    }

    public sealed record NotEnoughMoney : Result
    {
        public override string Message { get; init; }

        public NotEnoughMoney(string message)
        {
            Message = message;
        }
    }

    public sealed record WrongTransaction : Result
    {
        public override string Message { get; init; }

        public WrongTransaction(string message)
        {
            Message = message;
        }
    }
}