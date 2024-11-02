namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record Result
{
    public sealed record Success : Result { }

    public sealed record SuccessWithEntity<T> : Result
    {
        public T Entity { get; init; }

        public SuccessWithEntity(T entity)
        {
            Entity = entity;
        }
    }

    public sealed record NoSuchLectureIndex : Result { }

    public sealed record NotAuthor : Result { }

    public sealed record NotAuthorizedUser : Result { }

    public sealed record NotHundredScoresAtSubject : Result { }
}