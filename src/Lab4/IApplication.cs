using Itmo.ObjectOrientedProgramming.Lab4.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IApplication
{
    ApplicationFileSystemContext FileSystem { get; }

    IOutput Output { get; }

    void SetFileSystem(ApplicationFileSystemContext fileSystem);

    void SetOutput(IOutput output);
}