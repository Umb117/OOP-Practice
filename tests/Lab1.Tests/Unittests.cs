using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Xunit;

namespace Lab1.Tests;

public class UnitTests
{
    [Fact]
    public void ShouldSuccessfullyWhenSpeedIsRouteLimitReturnSuccess()
    {
        const int routeSpeedLimit = 25;
        const int weight = 5;
        const int force = 100;
        const int accuracy = 1;
        const int lenFirstPowerPath = 1;
        const int lenFSecondPath = 20;
        const int forceFirstPowerPath = 5;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddNotPowerPath(lenFSecondPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Success>(myResult);
    }

    [Fact]
    public void ShouldRouteLimitExceedWhenSpeedIsBiggerReturnFailure()
    {
        const int routeSpeedLimit = 25;
        const int weight = 5;
        const int force = 300;
        const int accuracy = 1;
        const int lenFirstPowerPath = 217;
        const int lenFSecondPath = 20;
        const int forceFirstPowerPath = 125;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddNotPowerPath(lenFSecondPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Failure.LimitOfSpeedError>(myResult);
    }

    [Fact]
    public void ShouldSuccessWhenStationAndRouteLimitIsOkReturnSuccess()
    {
        const int routeSpeedLimit = 25;
        const int passengers = 1;
        const int weight = 5;
        const int force = 300;
        const int accuracy = 1;
        const int lenFirstPowerPath = 23;
        const int lenSecondPath = 20;
        const int forceFirstPowerPath = 125;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddNotPowerPath(lenSecondPath);
        myRoute.CreateAndAddStation(routeSpeedLimit, passengers);
        myRoute.CreateAndAddNotPowerPath(lenSecondPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Success>(myResult);
    }

    [Fact]
    public void ShouldStationLimitExceedWhenSpeedIsBigReturnFailure()
    {
        const int routeSpeedLimit = 10000;
        const int stationSpeedLimit = 100;
        const int passengers = 1;
        const int weight = 5;
        const int force = 500;
        const int accuracy = 1;
        const int lenFirstPowerPath = 200;
        const int forceFirstPowerPath = 300;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddStation(stationSpeedLimit, passengers);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Failure.LimitOfSpeedError>(myResult);
    }

    [Fact]
    public void ShouldRouteLimitExceedWhenStationLimitIsOkReturnFailure()
    {
        const int weight = 5;
        const int force = 500;
        const int accuracy = 1;
        const int passengers = 1;
        const int stationSpeedLimit = 10000;
        const int routeSpeedLimit = 25;
        const int lenPowerPath = 123;
        const int lenFirstPath = 20;
        const int lenSecondPath = 23;
        const int forcePowerPath = 290;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenPowerPath, forcePowerPath);
        myRoute.CreateAndAddNotPowerPath(lenFirstPath);
        myRoute.CreateAndAddStation(stationSpeedLimit, passengers);
        myRoute.CreateAndAddNotPowerPath(lenSecondPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Failure.LimitOfSpeedError>(myResult);
    }

    [Fact]
    public void ShouldPassRouteWhenSpeedUpAndThenSpeedDownReturnSuccess()
    {
        const int weight = 2;
        const int force = 7000;
        const int accuracy = 1;
        const int passengers = 1;
        const int stationSpeedLimit = 9;
        const int routeSpeedLimit = 25;
        const int lenFirstPowerPath = 2;
        const int lenSecondPowerPath = 2;
        const int lenThirdPowerPath = 1;
        const int lenFourthPowerPath = 1;
        const int lenFirstPath = 10;
        const int lenSecondPath = 15;
        const int lenThirdPath = 20;
        const int forceFirstPowerPath = 16;
        const int forceSecondPowerPath = -12;
        const int forceThirdPowerPath = 40;
        const int forceFouthPowerPath = -25;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddNotPowerPath(lenFirstPath);
        myRoute.CreateAndAddPowerPath(lenSecondPowerPath, forceSecondPowerPath);
        myRoute.CreateAndAddStation(stationSpeedLimit, passengers);
        myRoute.CreateAndAddNotPowerPath(lenSecondPath);
        myRoute.CreateAndAddPowerPath(lenThirdPowerPath, forceThirdPowerPath);
        myRoute.CreateAndAddNotPowerPath(lenThirdPath);
        Result myResult = myRoute.StartTrainRide();
        myRoute.CreateAndAddPowerPath(lenFourthPowerPath, forceFouthPowerPath);

        Assert.IsType<Success>(myResult);
    }

    [Fact]
    public void ShouldStoppedRouteWhenNoPowerPathOnRouteReturnFailure()
    {
        const int weight = 5;
        const int force = 100;
        const int accuracy = 1;
        const int routeSpeedLimit = 25;
        const int lenFirstPath = 2;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddNotPowerPath(lenFirstPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Failure.StoppedOnHalfWay>(myResult);
    }

    [Fact]
    public void ShouldStoppedRouteWhenNegativeForceTwiceThanPositiveBeforeReturnFailure()
    {
        const int routeSpeedLimit = 105;
        const int weight = 5;
        const int force = 100;
        const int accuracy = 1;
        const int lenFirstPowerPath = 20;
        const int lenFSecondPowerPath = 20;
        const int forceFirstPowerPath = 5;
        const int forceSecondPowerPath = -10;

        var myRoute = new Route(routeSpeedLimit);
        myRoute.CreateTrain(weight, force, accuracy);
        myRoute.CreateAndAddPowerPath(lenFirstPowerPath, forceFirstPowerPath);
        myRoute.CreateAndAddPowerPath(lenFSecondPowerPath, forceSecondPowerPath);
        Result myResult = myRoute.StartTrainRide();

        Assert.IsType<Failure.StoppedOnHalfWay>(myResult);
    }
}