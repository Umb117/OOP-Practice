namespace Itmo.ObjectOrientedProgramming.Lab3;

public class GroupAdressees : IAdresee
{
    private readonly IList<IAdresee> _adressees;

    public GroupAdressees(IList<IAdresee> adressees)
    {
        _adressees = adressees;
    }

    public void GetMessage(Message message)
    {
        foreach (IAdresee adresee in _adressees)
        {
            adresee.GetMessage(message);
        }
    }

    public void Add(IAdresee adresee)
    {
        _adressees.Add(adresee);
    }

    public void Remove(IAdresee adresee)
    {
        _adressees.Remove(adresee);
    }
}