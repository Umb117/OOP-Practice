using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Entitles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class ExamSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectBuilder Create()
    {
        return new ExamSubject.ExamSubjectBuilder();
    }
}