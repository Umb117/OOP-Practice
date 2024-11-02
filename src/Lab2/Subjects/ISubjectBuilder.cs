using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubjectBuilder
{
    public ISubjectBuilder AddName(string name);

    public ISubjectBuilder AddExamScores(int scores);

    public ISubjectBuilder AddLectures(IList<ILecture> lectures);

    public ISubjectBuilder AddLabs(IList<ILaboratory> labs);

    public Result Build();
}