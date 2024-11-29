namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public string Path { get; init; }

    public LocalFileSystem(string path)
    {
        Path = path;
    }
}