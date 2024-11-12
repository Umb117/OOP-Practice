namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public string Name { get; set; }

    public IList<IAdresee> Addressees { get; }

    public Topic(string name, IList<IAdresee> addresses)
    {
        Name = name;
        Addressees = addresses;
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
        Addressees.Add(adressee);
    }
}