using ATM.Application.Exceptions;
using ATM.Interfaces.Authorization;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;

namespace ATM.Tests.Presentation
{
    [TestFixture]
    public class ATMMachineTests 
    {
        [Test]
        public void Given_cardNotInserted_When_WithdrawMoney_Then_shouldThrowCardNotInsertedException()
        {
            // Given 
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockCardReader = fixture.Freeze<Mock<ICardReader>>();
            mockCardReader.Setup(x => x.IsCardInserted()).Returns(false);
            var atMachine = fixture.Create<ATMachine>();

            // When // Then
            Assert.Throws<CardNotInsertedException>(() => atMachine.WithdrawMoney(123));
        }

        [Test]
        public void Given_cardInserted_When_WithdrawMoney_Then_shouldThrowCardNotInsertedException()
        {
            // Given 
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockCardReader = fixture.Freeze<Mock<ICardReader>>();
            mockCardReader.Setup(x => x.IsCardInserted()).Returns(true);
            var atMachine = fixture.Create<ATMachine>();

            // When 
            var result = atMachine.WithdrawMoney(123);

            // Then
            Assert.IsNotNull(result);
        }
    }
}
