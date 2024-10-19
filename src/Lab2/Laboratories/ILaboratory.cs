namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public interface ILaboratory
{
    public Laboratory Clone();

    public void Edit(int id, string? newName, string? newDescription);

    public void AddCriterias(string newCriteria, int newScore);
}