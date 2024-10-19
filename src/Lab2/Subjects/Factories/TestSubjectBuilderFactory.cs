using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class TestSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectBuilder Create()
    {
        return new TestSubjectBuilder();
    }
}