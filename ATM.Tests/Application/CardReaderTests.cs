using ATM.Application.Authorization;
using ATM.Models;
using NUnit.Framework;

namespace ATM.Tests.Application
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
            var card = new Card();
            ClassUnderTest.Insert(card);

            // When
            var result = ClassUnderTest.IsCardInserted();

            // Then
            Assert.IsTrue(result);
        }
    }
}
