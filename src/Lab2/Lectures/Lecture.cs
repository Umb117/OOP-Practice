using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class Lecture : ILecture
{
    private static int _generalId;
    private readonly int _authorId;

    public static LectureBuilder Builder => new LectureBuilder();

    public int Id { get; init; }

    public int? OriginalId { get; init; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    private Lecture(string name, string description, string content, int authorId, int? originalId = null)
    {
        Id = _generalId;
        Name = name;
        Description = description;
        Content = content;
        _authorId = authorId;
        OriginalId = originalId;
        _generalId++;
    }

    public class LectureBuilder : ILectureBuilder
    {
        private string? _name;
        private string? _description;
        private string? _content;

        public ILectureBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public ILectureBuilder AddDescription(string description)
        {
            _description = description;
            return this;
        }

        public ILectureBuilder AddContent(string content)
        {
            _content = content;
            return this;
        }

        public Result Build()
        {
            if (CurrentUser.CurrUser is null) return new Result.NotAuthorizedUser();
            return new Result.SuccessWithEntity<Lecture>(new Lecture(
                _name ?? throw new ArgumentNullException(),
                _description ?? throw new ArgumentNullException(),
                _content ?? throw new ArgumentNullException(),
                CurrentUser.CurrUser.Id));
        }
    }

    public ILecture Clone()
    {
        if (CurrentUser.CurrUser is null) throw new ArgumentNullException();
        return new Lecture(Name, Description, Content, CurrentUser.CurrUser.Id, Id);
    }

    public Result Edit(string? newName = null, string? newDescription = null, string? newContent = null)
    {
        if (!IsAuthor()) return new Result.NotAuthor();

        if (newName == null && newDescription == null && newContent == null) return new Result.Success();

        if (newName != null) Name = newName;
        if (newDescription != null) Description = newDescription;
        if (newContent != null) Content = newContent;
        return new Result.Success();
    }

    private bool IsAuthor()
    {
        if (CurrentUser.CurrUser is null) return false;
        return _authorId == CurrentUser.CurrUser.Id;
    }
}