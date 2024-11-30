namespace Itmo.ObjectOrientedProgramming.Lab4.Results;

public abstract record Result
{
    public sealed record Success : Result
    {
        public string Text { get; private set; }

        public Success(string text)
        {
            Text = text;
        }
    }

    public sealed record NoSuchSystem : Result;

    public sealed record NoFilesystemConnected : Result;
}