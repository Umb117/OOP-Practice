using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ApplicationFileSystemContext
{
    public IFileSystem? FileSystem { get; private set; }

    public ApplicationFileSystemContext(IFileSystem? fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void SetFileSystem(IFileSystem? fileSystem)
    {
        FileSystem = fileSystem;
    }
}