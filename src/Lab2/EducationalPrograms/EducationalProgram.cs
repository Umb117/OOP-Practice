using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEducationalProgram
{
    private static int _generalId;

    public static EducationalProgramBuilder Builder => new EducationalProgramBuilder();

    public int Id { get; init; }

    public int? AuthorId { get; init; }

    public Dictionary<int, List<ISubject>> Subjects { get; init; }

    public string Name { get; private set; }

    private EducationalProgram(string name, Dictionary<int, List<ISubject>> subjects, int authorId)
    {
        Id = _generalId;
        Name = name;
        Subjects = subjects;
        AuthorId = authorId;
        _generalId++;
    }

    public class EducationalProgramBuilder : IEducationalProgramBuilder
    {
        private string? _name;
        private Dictionary<int, List<ISubject>>? _subjects;

        public IEducationalProgramBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public IEducationalProgramBuilder AddSubjects(Dictionary<int, List<ISubject>> subjects)
        {
            _subjects = subjects;
            return this;
        }

        public Result Build()
        {
            if (CurrentUser.CurrUser is null) return new Result.NotAuthorizedUser();
            return new Result.SuccessWithEntity<EducationalProgram>(new EducationalProgram(
                _name ?? throw new ArgumentNullException(),
                _subjects ?? throw new ArgumentNullException(),
                CurrentUser.CurrUser.Id));
        }
    }

    public Result AddLab(int semester, ISubject newSubject)
    {
        if (!IsAuthor()) return new Result.NotAuthor();

        Subjects[semester].Add(newSubject);
        return new Result.Success();
    }

    public Result Edit(string? newName)
    {
        if (!IsAuthor()) return new Result.NotAuthor();

        if (newName == null) return new Result.Success();

        Name = newName;
        return new Result.Success();
    }

    private bool IsAuthor()
    {
        if (CurrentUser.CurrUser is null) return false;
        return AuthorId == CurrentUser.CurrUser.Id;
    }
}