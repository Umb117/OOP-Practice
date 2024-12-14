namespace Itmo.ObjectOrientedProgramming.Lab4.Results;

public abstract record ResultType
{
    public sealed record Success : ResultType
    {
        public string Text { get; private set; }

        public Success(string text)
        {
            Text = text;
        }
    }

    public sealed record NoSuchSystem : ResultType;

    public sealed record NoFilesystemConnected : ResultType;
}