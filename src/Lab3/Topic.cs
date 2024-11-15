namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public string Name { get; set; }

    public IReadOnlyCollection<IAdresee> Addressees => _addressees.AsReadOnly();

    private readonly IList<IAdresee> _addressees;

    public Topic(string name, IList<IAdresee> addresses)
    {
        Name = name;
        _addressees = addresses;
    }

    public void SendToAdressees(Message message)
    {
        foreach (IAdresee adresee in Addressees)
        {
            adresee.GetMessage(message);
        }
    }

    public void AddAdressee(IAdresee adressee)
    {
        _addressees.Add(adressee);
    }
}