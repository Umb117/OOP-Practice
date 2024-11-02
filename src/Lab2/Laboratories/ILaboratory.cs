using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public interface ILaboratory : IPrototype<ILaboratory>
{
    public int Id { get; init; }

    public int ScoresAmount { get; init; }

    public int? OriginalId { get; init; }

    public string Name { get; }

    public string Criterias { get; }

    public string Description { get; }

    public Result Edit(string? newName = null, string? newDescription = null, string? newCriterias = null);
}