using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Entitles;

public class ExamSubject : ISubject
{
    private static int _generalId;

    public int Id { get; init; }

    public int AuthorId { get; init; }

    public int? OriginalId { get; init; }

    public IList<ILaboratory> Labs { get; init; }

    public IList<ILecture> Lectures { get; private set; }

    public int Scores { get; private set; }

    public string Name { get; private set; }

    private ExamSubject(string name, int examScores, int authorId, IList<ILaboratory> labs, IList<ILecture> lectures, int? originalId = null)
    {
        Id = _generalId;
        Name = name;
        Scores = examScores;
        AuthorId = authorId;
        Labs = labs;
        Lectures = lectures;
        OriginalId = originalId;
        _generalId++;
    }

    public class ExamSubjectBuilder : ISubjectBuilder
    {
        private IList<ILaboratory>? _labs;
        private IList<ILecture>? _lectures;
        private int? _scores;
        private string? _name;

        public ISubjectBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public ISubjectBuilder AddExamScores(int scores)
        {
            _scores = scores;
            return this;
        }

        public ISubjectBuilder AddLectures(IList<ILecture> lectures)
        {
            _lectures = lectures;
            return this;
        }

        public ISubjectBuilder AddLabs(IList<ILaboratory> labs)
        {
            _labs = labs;
            return this;
        }

        public Result Build()
        {
            if (CurrentUser.CurrUser is null) return new Result.NotAuthorizedUser();
            if (_labs == null)
            {
                throw new ArgumentNullException();
            }

            int currentScores = _labs.Sum(lab => lab.ScoresAmount);
            currentScores += _scores ?? throw new ArgumentNullException();

            if (currentScores != 100)
            {
                return new Result.NotHundredScoresAtSubject();
            }

            return new Result.SuccessWithEntity<ExamSubject>(new ExamSubject(
                _name ?? throw new ArgumentNullException(),
                _scores ?? throw new ArgumentNullException(),
                CurrentUser.CurrUser.Id,
                _labs,
                _lectures ?? throw new ArgumentNullException()));
        }
    }

    public ISubject Clone()
    {
        if (CurrentUser.CurrUser is null) throw new ArgumentNullException();
        return new ExamSubject(Name, Scores, CurrentUser.CurrUser.Id, Labs, Lectures, Id);
    }

    public Result Edit(string? newName, int? newScores = null)
    {
        if (!IsAuthor()) return new Result.NotAuthor();

        if (newName == null && newScores == null) return new Result.Success();

        if (newName != null) Name = newName;
        return new Result.Success();
    }

    public Result EditLectures(int lectureIndex, string? newName = null, string? newDescription = null, string? newContent = null)
    {
        if (!IsAuthor()) return new Result.NotAuthor();
        if (lectureIndex < 0 || lectureIndex >= Lectures.Count) return new Result.NoSuchLectureIndex();
        Labs[lectureIndex].Edit(newName, newDescription, newContent);
        return new Result.Success();
    }

    private bool IsAuthor()
    {
        if (CurrentUser.CurrUser is null) return false;
        return AuthorId == CurrentUser.CurrUser.Id;
    }
}