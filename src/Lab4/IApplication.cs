using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IApplication
{
    IFileSystem? FileSystem { get; }

    string? CurrentPath { get; }

    IOutput Output { get; }

    void SetFileSystem(IFileSystem? fileSystem);

    void SetCurrentPath(string path);

    void SetOutput(IOutput output);
}