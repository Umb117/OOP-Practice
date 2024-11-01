using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public interface ILectureBuilder
{
    public ILectureBuilder AddName(string name);

    public ILectureBuilder AddDescription(string description);

    public ILectureBuilder AddContent(string content);

    public Result Build();
}