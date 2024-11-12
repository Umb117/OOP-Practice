using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class AllLab3Tests
{
    [Fact]
    public void Display_Test_Success()
    {
        var logger = new Logger();
        var displayMock = new Mock<IDisplay>();
        displayMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var displayDriver = new DisplayDriver(displayMock.Object);
        var displayProxy = new DisplayProxy(displayDriver, logger, 0, true);
        var adressees = new List<IAdresee>
        {
            displayProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);

        displayMock.Verify(h => h.GetMessage(It.IsAny<Message>()), Times.Once());
    }

    [Fact]
    public void ShouldSaveInUnreadMessagesWhenUserGetMessageSuccess()
    {
        var logger = new Logger();
        var user = new User("Name1");
        var userProxy = new UserProxy(user, logger);
        var adressees = new List<IAdresee>
        {
            userProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);

        Assert.Equal(message, user.UnReadMessages.Dequeue());
    }

    [Fact]
    public void ShouldStayReadMessageWhenUserChangeStatusUnreadMessageSuccess()
    {
        var logger = new Logger();
        var user = new User("Name1");
        var userProxy = new UserProxy(user, logger);
        var adressees = new List<IAdresee>
        {
            userProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);
        user.ReadMessage();

        Assert.True(user.UnReadMessages.Count == 0);
        Assert.Equal(message, user.ReadMessages.Dequeue());
    }

    [Fact]
    public void ShouldErrorWhenUserChangeStatusReadenMessageFailure()
    {
        var logger = new Logger();
        var user = new User("Name1");
        var userProxy = new UserProxy(user, logger);
        var adressees = new List<IAdresee>
        {
            userProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);
        user.ReadMessage();
        Result result = user.ReadMessage();

        Assert.True(user.UnReadMessages.Count == 0);
        Assert.IsType<Result.NoUnreadMessagesFail>(result);
    }

    [Fact]
    public void MessageShouldntGoToAdresseerWhenImportanceLessThenNeedFailure()
    {
        var logger = new Logger();
        var displayMock = new Mock<IDisplay>();
        displayMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var displayDriver = new DisplayDriver(displayMock.Object);
        var displayProxy = new DisplayProxy(displayDriver, logger, 5);
        var messengerMock = new Mock<IMessenger>();
        messengerMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var messengerProxy = new MessengerProxy(messengerMock.Object, logger, 5);
        var userMock = new Mock<IUser>();
        userMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var userProxy = new UserProxy(userMock.Object, logger, 5);
        var adressees = new List<IAdresee>
        {
            displayProxy,
            messengerProxy,
            userProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);

        displayMock.Verify(h => h.GetMessage(It.IsAny<Message>()), Times.Never);
        messengerMock.Verify(h => h.GetMessage(It.IsAny<Message>()), Times.Never);
        userMock.Verify(h => h.GetMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void ShouldnLoggingWhenImportanceLessThenNeedFailure()
    {
        var loggerMock = new Mock<ILogger>();
        loggerMock.Setup(h => h.Log(It.IsAny<Message>()));
        var displayMock = new Mock<IDisplay>();
        displayMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var displayDriver = new DisplayDriver(displayMock.Object);
        var displayProxy = new DisplayProxy(displayDriver, loggerMock.Object, 0, true);
        var messengerMock = new Mock<IMessenger>();
        messengerMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var messengerProxy = new MessengerProxy(messengerMock.Object, loggerMock.Object, 0, true);
        var userMock = new Mock<IUser>();
        userMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var userProxy = new UserProxy(userMock.Object, loggerMock.Object, 0, true);
        var adressees = new List<IAdresee>
        {
            displayProxy,
            messengerProxy,
            userProxy,
        };
        var topic = new Topic("Topic1", adressees);
        var message = new Message("Name", "Text", 0);
        var publisher = new Publisher();

        publisher.PostMessage(topic, message);

        loggerMock.Verify(h => h.Log(It.IsAny<Message>()), Times.Exactly(3));
    }

    [Fact]
    public void ShouldPrintTextMessageWhenMessengerHaveMessageSuccess()
    {
        var logger = new Logger();
        var messengerMock = new Mock<IMessenger>();
        messengerMock.Setup(h => h.PrintText());
        var messengerProxy = new MessengerProxy(messengerMock.Object, logger, 0, true);
        var message = new Message("Name", "Text", 0);
        messengerProxy.GetMessage(message);

        messengerProxy.PrintText();
        messengerMock.Verify(h => h.PrintText(), Times.Once());
    }

    [Fact]
    public void OneUserShouldHaveMessageOnceWhenTwoAdresseeWithDifMinImportanceLevelSuccess()
    {
        var logger = new Logger();
        var userMock = new Mock<IUser>();
        userMock.Setup(h => h.GetMessage(It.IsAny<Message>()));
        var userProxy1 = new UserProxy(userMock.Object, logger, 0, true);
        var userProxy2 = new UserProxy(userMock.Object, logger, 5, true);
        var message = new Message("Name", "Text", 0);

        userProxy1.GetMessage(message);
        userProxy2.GetMessage(message);

        userMock.Verify(h => h.GetMessage(It.IsAny<Message>()), Times.Once());
    }
}