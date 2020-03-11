using ATM.Application.Authorization;
using AutoFixture;
using NUnit.Framework;

namespace ATM.Tests.Application.Authorization
{
    [TestFixture]
    public class CardReaderTests : AutoMockedTests<CardReader>
    {
        [Test]
        public void Given_userDidntInsertCard_When_isCardInserted_Should_returnFalse()
        {
            // Given // When
            var result = ClassUnderTest.IsCardInserted();

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Given_userInsertedCard_When_isCardInserted_Should_returnTrue()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            ClassUnderTest.Insert(cardNumber);

            // When
            var result = ClassUnderTest.IsCardInserted();

            // Then
            Assert.IsTrue(result);
        }

        [Test]
        public void Given_userInsertedCard_When_GetCurrentCardNumber_Should_returnSameNumber()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            ClassUnderTest.Insert(cardNumber);

            // When
            var result = ClassUnderTest.CurrentCardNumber;

            // Then
            Assert.AreEqual(cardNumber, result);
        }
    }
}
