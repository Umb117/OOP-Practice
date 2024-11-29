using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

public class OutputVisitor : IFileSystemComponentVisitor
{
    private readonly int _maxDepth;
    private int _depth;

    public string Text { get; private set; }

    public OutputVisitor(int maxDepth)
    {
        _maxDepth = maxDepth;
        Text = string.Empty;
    }

    public void Visit(FileFileSystemComponent component)
    {
        WriteIndented(component.Name);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        WriteIndented(component.Name);

        _depth += 1;

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this);
        }

        _depth -= 1;
    }

    private void WriteIndented(string value)
    {
        if (!(_depth <= _maxDepth)) return;

        if (_depth is not 0)
        {
            Text += string.Concat(Enumerable.Repeat("   ", _depth));
            Text += "|–> ";
        }

        Text += value;
        Text += "\n";
    }
}