using ATM.Application.Fees;
using ATM.Interfaces.Application.Utility;
using AutoFixture;
using NUnit.Framework;
using System;

namespace ATM.Tests.Application.Fees
{
    [TestFixture]
    public class FeeFactoryTests : AutoMockedTests<FeeFactory>
    {
        [Test]
        public void Given_values_When_Create_Then_shouldCreateFee()
        {
            // Given
            var dateTime = Fixture.Create<DateTime>();
            var feeAmount = Fixture.Create<decimal>();
            var cardNumber = Fixture.Create<string>();
            GetMock<IDateTimeFacade>().Setup(x => x.UtcNow()).Returns(dateTime);

            // When
            var result = ClassUnderTest.Create(cardNumber, feeAmount);

            // Then
            Assert.AreEqual(cardNumber, result.CardNumber);
            Assert.AreEqual(feeAmount, result.WithdrawalFeeAmount);
            Assert.AreEqual(dateTime, result.WithdrawalDate);
        }
    }
}
