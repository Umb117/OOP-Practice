using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEducationalProgram
{
    private static int _generalId;
    private readonly int _id;
    private readonly int _authorId;
    private readonly List<ILaboratory> _labs;
    private readonly List<ILection> _lections;

    private string _name;
    private string _semester;

    public EducationalProgram(string name, int authorId, string semester)
    {
        _id = _generalId;
        _name = name;
        _semester = semester;
        _authorId = authorId;
        _labs = new List<ILaboratory>();
        _lections = new List<ILection>();
        _generalId++;
    }

    public void AddLab(ILaboratory newLab)
    {
        _labs.Add(newLab);
    }

    public void AddLection(ILection newLection)
    {
        _lections.Add(newLection);
    }

    public void Edit(int id, string? newName, string? newSemester)
    {
        if (!IsAutor(id)) return;

        if (newName == null && newSemester == null) return;

        if (newName != null) EditName(newName);
        if (newSemester != null) EditSemester(newSemester);
    }

    private bool IsAutor(int id)
    {
        return _authorId == id;
    }

    private void EditName(string newName)
    {
        _name = newName;
    }

    private void EditSemester(string newSemester)
    {
        _semester = newSemester;
    }
}