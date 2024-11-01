using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;
using Itmo.ObjectOrientedProgramming.Lab2.Laboratories;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Entitles;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class AllTests
{
    [Fact]
    public void CreateAllEntitlesSuccess()
    {
        var author1 = new User("Name1");
        CurrentUser.CurrUser = author1;
        Laboratory lab = CreateLabworkSuccess(40);
        Lecture lecture = CreateLectureSuccess();
        var lectures = new List<ILecture>
        {
            lecture,
        };
        var labs = new List<ILaboratory>
        {
            lab,
        };
        ExamSubject examSubject = CreateExamSubjectSuccess(lectures, labs, 60);
        var subjectsBySemesters = new Dictionary<int, List<ISubject>>
        {
            {
                1, [
                    examSubject
                ]
            },
        };
        EducationalProgram educationalProgram = CreateEducationalProgramSuccess(subjectsBySemesters);

        Assert.IsType<EducationalProgram>(educationalProgram);
    }

    [Fact]
    public void CloneShouldWorkWhenCloneOnCloneReturnSuccess()
    {
        var author1 = new User("Name1");
        CurrentUser.CurrUser = author1;
        Laboratory lab = CreateLabworkSuccess(20);
        ILaboratory lab2 = lab.Clone().Clone().Clone();

        Assert.Equal(lab.Id + 3, lab2.Id);
    }

    [Fact]
    public void EntitlesShouldHaveOriginalIdWhenCloneReturnSuccess()
    {
        var author1 = new User("Name1");
        CurrentUser.CurrUser = author1;
        Laboratory lab = CreateLabworkSuccess(20);
        ILaboratory lab2 = lab.Clone();

        Assert.Equal(0, lab.Id);
        Assert.Equal(0, lab2.OriginalId);
    }

    [Fact]
    public void RepositoriesShouldWorkReturnSuccess()
    {
        var author1 = new User("Name1");
        CurrentUser.CurrUser = author1;
        Lecture lecture = CreateLectureSuccess();
        Laboratory lab = CreateLabworkSuccess(40);
        var lectures = new List<ILecture>
        {
            lecture,
        };
        var labs = new List<ILaboratory>
        {
            lab,
        };
        ExamSubject examSubject = CreateExamSubjectSuccess(lectures, labs, 60);
        var subjectsBySemesters = new Dictionary<int, List<ISubject>>
        {
            {
                1, [
                    examSubject
                ]
            },
        };
        EducationalProgram educationalProgram = CreateEducationalProgramSuccess(subjectsBySemesters);
        var lectureRepo = new Repository<ILecture>();
        var labRepo = new Repository<ILaboratory>();
        var subjectRepo = new Repository<ISubject>();
        var educationalProgramRepo = new Repository<IEducationalProgram>();

        lectureRepo.AddEntity(lecture.Id, lecture);
        labRepo.AddEntity(lab.Id, lab);
        subjectRepo.AddEntity(examSubject.Id, examSubject);
        educationalProgramRepo.AddEntity(educationalProgram.Id, educationalProgram);
        lectureRepo.FindEntity(lecture.Id);
        labRepo.FindEntity(lab.Id);
        subjectRepo.FindEntity(examSubject.Id);
        educationalProgramRepo.FindEntity(educationalProgram.Id);

        Assert.Equal(lectureRepo.FindEntity(lecture.Id), lecture);
        Assert.Equal(labRepo.FindEntity(lab.Id), lab);
        Assert.Equal(subjectRepo.FindEntity(examSubject.Id), examSubject);
        Assert.Equal(educationalProgramRepo.FindEntity(educationalProgram.Id), educationalProgram);
    }

    [Fact]
    public void ShouldFailWhenSubjectHaveNotHundredScoresReturnFailure()
    {
        var author1 = new User("Name1");
        CurrentUser.CurrUser = author1;
        Laboratory lab1 = CreateLabworkSuccess(10);
        Laboratory lab2 = CreateLabworkSuccess(15);
        Lecture lecture = CreateLectureSuccess();
        var lectures = new List<ILecture>
        {
            lecture,
        };
        var labs = new List<ILaboratory>
        {
            lab1, lab2,
        };
        var examSubjectBuilderFactory = new ExamSubjectBuilderFactory();
        ISubjectBuilder examSubjectBuilder = examSubjectBuilderFactory.Create();
        Result resultOfSubjectBuilding1 = examSubjectBuilder.AddName("ExamSubject1")
            .AddLectures(lectures)
            .AddLabs(labs)
            .AddExamScores(30)
            .Build();
        var testSubjectBuilderFactory = new TestSubjectBuilderFactory();
        ISubjectBuilder testSubjectBuilder = testSubjectBuilderFactory.Create();
        Result resultOfSubjectBuilding2 = testSubjectBuilder.AddName("TestSubject1")
            .AddLectures(lectures)
            .AddLabs(labs)
            .AddExamScores(60)
            .Build();

        Assert.IsType<Result.NotHundredScoresAtSubject>(resultOfSubjectBuilding1);
        Assert.IsType<Result.NotHundredScoresAtSubject>(resultOfSubjectBuilding2);
    }

    [Fact]
    public void EntitlesShouldFailWhenNotAuthorEditingReturnFailure()
    {
        var author1 = new User("Name1");
        var author2 = new User("Name2");
        CurrentUser.CurrUser = author1;
        Laboratory lab = CreateLabworkSuccess(80);
        Lecture lecture = CreateLectureSuccess();
        var lectures = new List<ILecture>
        {
            lecture,
        };
        var labs = new List<ILaboratory>
        {
            lab,
        };
        ExamSubject examSubject = CreateExamSubjectSuccess(lectures, labs, 20);
        var subjectsBySemesters = new Dictionary<int, List<ISubject>>
        {
            {
                1, [
                    examSubject
                ]
            },
        };
        EducationalProgram educationalProgram = CreateEducationalProgramSuccess(subjectsBySemesters);
        CurrentUser.CurrUser = author2;

        Assert.IsType<Result.NotAuthor>(lab.Edit("New Name"));
        Assert.IsType<Result.NotAuthor>(lecture.Edit("New Name"));
        Assert.IsType<Result.NotAuthor>(examSubject.Edit("New Name"));
        Assert.IsType<Result.NotAuthor>(educationalProgram.Edit("New Name"));
    }

    private Laboratory CreateLabworkSuccess(int scores)
    {
        Result resultOfLabBuilding = Laboratory.Builder.AddName("LabName2").AddCriterias("Criterias2")
            .AddDescription("Description2")
            .AddScoresAmount(scores)
            .Build();
        Laboratory lab = ((Result.SuccessWithEntity<Laboratory>)resultOfLabBuilding).Entity;
        return lab;
    }

    private Lecture CreateLectureSuccess()
    {
        Result resultOfLectureBuilding = Lecture.Builder.AddName("Lecture1")
            .AddDescription("Description1")
            .AddContent("Content")
            .Build();
        Lecture lecture = ((Result.SuccessWithEntity<Lecture>)resultOfLectureBuilding).Entity;
        return lecture;
    }

    private ExamSubject CreateExamSubjectSuccess(List<ILecture> lectures, List<ILaboratory> labs, int scores)
    {
        var examSubjectBuilderFactory = new ExamSubjectBuilderFactory();
        ISubjectBuilder examSubjectBuilder = examSubjectBuilderFactory.Create();
        Result resultOfSubjectBuilding = examSubjectBuilder.AddName("ExamSubject1")
            .AddLectures(lectures)
            .AddLabs(labs)
            .AddExamScores(scores)
            .Build();
        ExamSubject examSubject = ((Result.SuccessWithEntity<ExamSubject>)resultOfSubjectBuilding).Entity;
        return examSubject;
    }

    private EducationalProgram CreateEducationalProgramSuccess(Dictionary<int, List<ISubject>> subjectsBySemesters)
    {
        Result resultOfEducationalProgramBuilding = EducationalProgram.Builder.AddName("Lecture1")
            .AddSubjects(subjectsBySemesters)
            .Build();
        EducationalProgram educationalProgram = ((Result.SuccessWithEntity<EducationalProgram>)resultOfEducationalProgramBuilding).Entity;
        return educationalProgram;
    }
}