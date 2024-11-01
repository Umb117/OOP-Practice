using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Entitles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class TestSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectBuilder Create()
    {
        return new TestSubject.TestSubjectBuilder();
    }
}