namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public string GlobalPath { get; }

    public string? CurrentPath { get; private set; }

    public LocalFileSystem(string path)
    {
        GlobalPath = path;
    }

    public void SetCurrentPath(string path)
    {
        CurrentPath = path;
    }

    public void CopyTo(string sourcePath, string destinationPath)
    {
        var fileInfo = new FileInfo(sourcePath);
        fileInfo.CopyTo(destinationPath);
    }

    public void Delete(string path)
    {
        var fileInfo = new FileInfo(path);
        fileInfo.Delete();
    }

    public void MoveTo(string sourcePath, string destinationPath)
    {
        var fileInfo = new FileInfo(sourcePath);
        fileInfo.MoveTo(destinationPath);
    }

    public void Rename(string path, string name)
    {
        var fileInfo = new FileInfo(path);
        string? dirName = Path.GetDirectoryName(path);
        if (dirName is not null)
        {
            string newPath = Path.Combine(dirName, name);
            fileInfo.MoveTo(newPath);
        }

        fileInfo.MoveTo(name);
    }

    public string ReadAllText(string path)
    {
        string res = string.Empty;
        using StreamReader sr = File.OpenText(path);
        while (sr.ReadLine() is { } s)
        {
            res += s;
            res += "\n";
        }

        return res;
    }

    public string? GetFileName(string? path)
    {
        return Path.GetFileName(path);
    }
}