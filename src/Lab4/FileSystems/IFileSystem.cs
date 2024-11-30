namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    string GlobalPath { get; }

    string? CurrentPath { get; }

    void SetCurrentPath(string path);

    void CopyTo(string sourcePath, string destinationPath);

    void Delete(string path);

    void MoveTo(string sourcePath, string destinationPath);

    void Rename(string path, string name);

    string ReadAllText(string path);

    string? GetFileName(string? path);
}