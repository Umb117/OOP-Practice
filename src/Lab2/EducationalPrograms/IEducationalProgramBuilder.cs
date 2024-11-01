using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public interface IEducationalProgramBuilder
{
    public IEducationalProgramBuilder AddName(string name);

    public IEducationalProgramBuilder AddSubjects(Dictionary<int, List<ISubject>> subjects);

    public Result Build();
}