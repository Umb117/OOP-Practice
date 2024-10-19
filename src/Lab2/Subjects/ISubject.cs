namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject
{
    public ISubject Clone();

    public void EditName(string newName);

    public void EditLabs(string newDescription);

    public void EditLectures(string newContent);
}