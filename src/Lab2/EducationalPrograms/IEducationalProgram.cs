using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public interface IEducationalProgram
{
    public void Edit(int id, string? newName, string? newSemester);

    public void AddLab(int id, ILaboratory newLab);

    public void AddLection(int id, ILection newLection);
}