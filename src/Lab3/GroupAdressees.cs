namespace Itmo.ObjectOrientedProgramming.Lab3;

public class GroupAdressees : IAdresee
{
    public int MinImportanceLevel { get; set; }

    public bool Logging { get; set; }

    public ILogger Logger { get; set; }

    public IList<IAdresee> Adressees { get; }

    public GroupAdressees(IList<IAdresee> adressees)
    {
        Adressees = adressees;
        Logger = new Logger();
    }

    public void GetMessage(Message message)
    {
        foreach (IAdresee adresee in Adressees)
        {
            adresee.GetMessage(message);
        }
    }

    public void Add(IAdresee adresee)
    {
        Adressees.Add(adresee);
    }

    public void Remove(IAdresee adresee)
    {
        Adressees.Remove(adresee);
    }
}