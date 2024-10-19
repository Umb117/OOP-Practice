namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public interface ILection
{
    public Lection Clone();

    public void Edit(int id, string? newName, string? newDescription, string? newContent);
}