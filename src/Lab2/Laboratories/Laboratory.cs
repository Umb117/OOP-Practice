namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public class Laboratory : ILaboratory, IPrototype<Laboratory>
{
    private static int _generalId;
    private readonly int _id;
    private readonly Dictionary<string, int> _criterias;
    private readonly int _scoresAmount;

    public int? OriginalId { get; init; }

    private readonly int _authorId;
    private string _name;
    private string _description;

    public Laboratory(Dictionary<string, int>? criterias, string name, string description, int scoresAmount, int authorId, int? originalId = null)
    {
        _criterias = criterias ?? new Dictionary<string, int>();
        _id = _generalId;
        _name = name;
        _description = description;
        _scoresAmount = scoresAmount;
        _authorId = authorId;
        OriginalId = originalId;
        _generalId++;
    }

    public void Edit(int id, string? newName, string? newDescription)
    {
        if (!IsAutor(id)) return;

        if (newName == null && newDescription == null) return;

        if (newName != null) EditName(newName);
        if (newDescription != null) EditDescription(newDescription);
    }

    public Laboratory Clone()
    {
        return new Laboratory(_criterias, _name, _description, _scoresAmount, _authorId, _id);
    }

    public void AddCriterias(string newCriteria, int newScore)
    {
        _criterias[newCriteria] = newScore;
    }

    private void EditName(string newName)
    {
        _name = newName;
    }

    private void EditDescription(string newDescription)
    {
        _description = newDescription;
    }

    private bool IsAutor(int id)
    {
        return _authorId == id;
    }
}