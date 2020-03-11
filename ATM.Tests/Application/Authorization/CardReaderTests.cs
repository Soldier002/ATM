using ATM.Application.Authorization;
using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Data.ThisATMachine;
using AutoFixture;
using Moq;
using NUnit.Framework;

namespace ATM.Tests.Application.Authorization
{
    [TestFixture]
    public class CardReaderTests : AutoMockedTests<CardReader>
    {
        [Test]
        public void Given_userDidntInsertCard_When_IsCardInserted_Then_shouldReturnFalse()
        {
            // Given // When
            var result = ClassUnderTest.IsCardInserted;

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Given_userInsertedCard_When_IsCardInserted_Then_shouldReturnTrue()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            GetMock<ICardService>().Setup(x => x.CardExists(cardNumber)).Returns(true);
            GetMock<IThisATMachineState>().SetupProperty(x => x.InsertedCardNumber);

            // When
            ClassUnderTest.Insert(cardNumber);
            var result = ClassUnderTest.IsCardInserted;

            // Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Given_userInsertedCard_When_GetCurrentCardNumber_Then_shouldReturnSameNumber()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            GetMock<ICardService>().Setup(x => x.CardExists(cardNumber)).Returns(true);
            GetMock<IThisATMachineState>().SetupProperty(x => x.InsertedCardNumber);

            // When
            ClassUnderTest.Insert(cardNumber);
            var result = ClassUnderTest.InsertedCardNumber;

            // Then
            Assert.AreEqual(cardNumber, result);
        }

        [Test]
        public void Given_cardDoesNotExist_When_Insert_Then_shouldThrowException()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            GetMock<ICardService>().Setup(x => x.CardExists(cardNumber)).Returns(false);

            // When // Then
            Assert.Throws<CardDoesNotExistException>(() => ClassUnderTest.Insert(cardNumber));
        }

        [Test]
        public void Given_cardIsInserted_When_Remove_Then_shouldRemoveCard()
        {
            // Given
            var mockThisATMachineState = GetMock<IThisATMachineState>();

            // When
            ClassUnderTest.Remove();

            // Then
            mockThisATMachineState.VerifySet(x => x.InsertedCardNumber = null, Times.Once);
        }
    }
}
