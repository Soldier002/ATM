using ATM.Application.Exceptions;
using ATM.Interfaces.Authorization;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;

namespace ATM.Tests.Presentation
{
    [TestFixture]
    public class ATMMachineTests : AutoMockedTests<ATMachine>
    {
        [Test]
        public void Given_cardNotInserted_When_WithdrawMoney_Then_shouldThrowCardNotInsertedException()
        {
            // Given 
            var mockCardReader = Fixture.Freeze<Mock<ICardReader>>();
            mockCardReader.Setup(x => x.IsCardInserted()).Returns(false);

            // When // Then
            Assert.Throws<CardNotInsertedException>(() => ClassUnderTest.WithdrawMoney(123));
        }

        [Test]
        public void Given_cardInserted_When_WithdrawMoney_Then_shouldThrowCardNotInsertedException()
        {
            // Given 
            var mockCardReader = Fixture.Freeze<Mock<ICardReader>>();
            mockCardReader.Setup(x => x.IsCardInserted()).Returns(true);

            // When 
            var result = ClassUnderTest.WithdrawMoney(123);

            // Then
            Assert.IsNotNull(result);
        }
    }
}
