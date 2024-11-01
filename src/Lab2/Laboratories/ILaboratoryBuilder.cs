using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public interface ILaboratoryBuilder
{
    public ILaboratoryBuilder AddName(string name);

    public ILaboratoryBuilder AddDescription(string description);

    public ILaboratoryBuilder AddScoresAmount(int scoresAmount);

    public ILaboratoryBuilder AddCriterias(string criterias);

    public Result Build();
}