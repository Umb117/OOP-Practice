namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratories;

public interface ILaboratoryBuilder
{
    public ILaboratoryBuilder AddName(string name);

    public ILaboratoryBuilder AddDescription(string description);

    public ILaboratoryBuilder AddScoresAmount(int scoresAmount);

    public ILaboratoryBuilder AddAuthorId(int authorId);

    public ILaboratoryBuilder AddCriteria(string criteria, int scores);

    public Laboratory Build();
}