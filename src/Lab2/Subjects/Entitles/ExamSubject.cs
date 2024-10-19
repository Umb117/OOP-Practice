using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Entitles;

public class ExamSubject : ISubject
{
    private static int _generalId = 0;
    private readonly int _id;

    public int? OriginalId { get; init; }

    private readonly int _authorId;
    private string _name;
    private readonly List<ILaboratory> _labs;
    private readonly List<ILection> _lections;
    private int _examScores;

    public ISubject Clone()
    {
        return new ExamSubject();
    }

    public void EditName(string newName);

    public void EditLabs(string newDescription);

    public void EditLectures(string newContent);
}