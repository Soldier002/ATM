using ATM.Application.Fees;
using ATM.Interfaces.Data.Bank;
using ATM.Models;
using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATM.Tests.Application.Fees
{
    [TestFixture]
    public class FeeServiceTests : AutoMockedTests<FeeService>
    {
        [Test]
        public void Given_cardNumber_When_GetAll_Then_shouldReturnFees()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            var fees = new List<Fee>();
            GetMock<IFeeRepository>().Setup(x => x.GetAll(cardNumber)).Returns(fees);

            // When
            var result = ClassUnderTest.GetAll(cardNumber);

            // Then
            Assert.AreEqual(fees, result);
        }
    }
}
