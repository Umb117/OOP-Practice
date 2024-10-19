namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public class LaboratoryBuilder : ILaboratoryBuilder
{
#pragma warning disable SK1500
    private readonly Dictionary<string, int> _criterias = new Dictionary<string, int>();
#pragma warning restore SK1500
    private string? _name;
    private string? _description;
    private int? _scoresAmount;
    private int? _authorId;

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

    public ILaboratoryBuilder AddAuthorId(int authorId)
    {
        _authorId = authorId;
        return this;
    }

    public ILaboratoryBuilder AddCriteria(string criteria, int scores)
    {
        _criterias[criteria] = scores;
        return this;
    }

    public Laboratory Build()
    {
        return new Laboratory(
            _criterias,
            _name ?? throw new ArgumentNullException(),
            _description ?? throw new ArgumentNullException(),
            _scoresAmount ?? throw new ArgumentNullException(),
            _authorId ?? throw new ArgumentNullException());
    }
}