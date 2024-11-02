using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public interface ILecture : IPrototype<ILecture>
{
    int Id { get; }

    int? OriginalId { get; init; }

    string Name { get; }

    string Description { get; }

    string Content { get; }

    public Result Edit(string? newName = null, string? newDescription = null, string? newContent = null);
}