using ATM.Application.Authorization;
using ATM.Models;
using NUnit.Framework;

namespace ATM.Tests.Application
{
    [TestFixture]
    public class CardReaderTests
    {
        [Test]
        public void Given_userDidntInsertCard_When_isCardInserted_Should_returnFalse()
        {
            // Given
            var cardReader = new CardReader();

            // When
            var result = cardReader.IsCardInserted();

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Given_userInsertedCard_When_isCardInserted_Should_returnTrue()
        {
            // Given
            var card = new Card();
            var cardReader = new CardReader();

            cardReader.Insert(card);

            // When
            var result = cardReader.IsCardInserted();

            // Then
            Assert.IsTrue(result);
        }
    }
}
