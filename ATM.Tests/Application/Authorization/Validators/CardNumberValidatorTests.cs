using ATM.Application.Authorization.Exceptions;
using ATM.Application.Authorization.Validators;
using NUnit.Framework;

namespace ATM.Tests.Application.Authorization.Validators
{
    [TestFixture]
    public class CardNumberValidatorTests : AutoMockedTests<CardNumberValidator>
    {
        [Test]
        public void Given_stringContains16NonDigits_When_Validate_Then_shouldThrowException()
        {
            // Given
            var cardNumber = "aaaabbbbccccdddd";

            // When // Then
            Assert.Throws<InvalidCardNumberException>(() => ClassUnderTest.Validate(cardNumber));
        }

        [Test]
        public void Given_stringContainsWrongAmountOfDigits_When_Validate_Then_shouldThrowException()
        {
            // Given
            var cardNumber = "10002000";

            // When // Then
            Assert.Throws<InvalidCardNumberException>(() => ClassUnderTest.Validate(cardNumber));
        }

        [Test]
        public void Given_16Digits_When_Validate_Then_shouldNotThrow()
        {
            // Given
            var cardNumber = "5555444433332222";

            // When // Then
            Assert.DoesNotThrow(() => ClassUnderTest.Validate(cardNumber));
        }
    }
}
