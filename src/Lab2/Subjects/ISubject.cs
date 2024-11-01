using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject : IPrototype<ISubject>
{
    public int Id { get; init; }

    public int AuthorId { get; init; }

    public int? OriginalId { get; init; }

    public IList<ILaboratory> Labs { get; }

    public IList<ILecture> Lectures { get; }

    public int Scores { get; }

    public string Name { get; }

    public Result Edit(string? newName, int? newScores);

    public Result EditLectures(
        int lectureIndex,
        string? newName,
        string? newDescription,
        string? newContent);
}