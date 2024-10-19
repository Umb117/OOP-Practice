namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubjectBuilder
{
    ISubjectBuilder AddName(string subject);

    ISubjectBuilder AddBBB(string subject);

    ISubject Build();
}