namespace Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;

public class FileSystemComponentFactory
{
    public IFileSystemComponent Create(string path)
    {
        if (Directory.Exists(path))
        {
            string? name = Path.GetFileName(path);

            string[] entries = Directory.EnumerateFileSystemEntries(path).ToArray();
            var names = new List<string>();

            foreach (string entry in entries)
            {
                string fileName = Path.GetFileName(entry);
                if (fileName != null)
                {
                    names.Add(fileName);
                }
            }

            var components = new IFileSystemComponent[names.Count];
            for (int i = 0; i < names.Count; i++)
            {
                components[i] = Create(Path.Combine(path, names[i]));
            }

            return new DirectoryFileSystemComponent(name ?? string.Empty, components);
        }

        if (File.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileFileSystemComponent(name);
        }

        throw new InvalidOperationException($"File system component at {path} is not found");
    }
}