using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public class Laboratory : ILaboratory
{
    private static int _generalId;
    private readonly int _authorId;

    public static LaboratoryBuilder Builder => new LaboratoryBuilder();

    public int Id { get; init; }

    public int ScoresAmount { get; init; }

    public int? OriginalId { get; init; }

    public string Name { get; private set; }

    public string Criterias { get; private set; }

    public string Description { get; private set; }

    private Laboratory(string criterias, string name, string description, int scoresAmount, int authorId, int? originalId = null)
    {
        Criterias = criterias;
        Id = _generalId;
        Name = name;
        Description = description;
        ScoresAmount = scoresAmount;
        _authorId = authorId;
        OriginalId = originalId;
        _generalId++;
    }

    public class LaboratoryBuilder : ILaboratoryBuilder
    {
        private string? _criterias;
        private string? _name;
        private string? _description;
        private int? _scoresAmount;

        public ILaboratoryBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public ILaboratoryBuilder AddDescription(string description)
        {
            _description = description;
            return this;
        }

        public ILaboratoryBuilder AddScoresAmount(int scoresAmount)
        {
            _scoresAmount = scoresAmount;
            return this;
        }

        public ILaboratoryBuilder AddCriterias(string criterias)
        {
            _criterias = criterias;
            return this;
        }

        public Result Build()
        {
            if (CurrentUser.CurrUser is null) return new Result.NotAuthorizedUser();
            return new Result.SuccessWithEntity<Laboratory>(new Laboratory(
                _criterias ?? throw new ArgumentNullException(),
                _name ?? throw new ArgumentNullException(),
                _description ?? throw new ArgumentNullException(),
                _scoresAmount ?? throw new ArgumentNullException(),
                CurrentUser.CurrUser.Id));
        }
    }

    public Result Edit(string? newName = null, string? newDescription = null, string? newCriterias = null)
    {
        if (!IsAuthor()) return new Result.NotAuthor();

        if (newName == null && newDescription == null) return new Result.Success();

        if (newName != null) Name = newName;
        if (newDescription != null) Description = newDescription;
        if (newCriterias != null) Criterias = newCriterias;
        return new Result.Success();
    }

    public ILaboratory Clone()
    {
        if (CurrentUser.CurrUser is null) throw new ArgumentNullException();
        return new Laboratory(Criterias, Name, Description, ScoresAmount, CurrentUser.CurrUser.Id, Id);
    }

    private bool IsAuthor()
    {
        if (CurrentUser.CurrUser is null) return false;
        return _authorId == CurrentUser.CurrUser.Id;
    }
}