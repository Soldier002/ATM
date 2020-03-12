﻿using ATM.Application.MoneyOperations.Bank;
using ATM.Interfaces.Application.Configuration;
using NUnit.Framework;

namespace ATM.Tests.Application.MoneyOperations.Bank
{
    [TestFixture]
    public class WithdrawalFeeCalculatorTests : AutoMockedTests<WithdrawalFeeCalculator>
    {
        [Test]
        public void Given_amountToWithdraw_When_Calculate_Then_shouldUseWithdrawalFeePercentageFromConfiguration()
        {
            // Given
            var withdrawalFeePercetange = 0.01m;
            var withdrawnAmount = 100m;
            GetMock<IConfiguration>().Setup(x => x.WithdrawalFeePercentage).Returns(withdrawalFeePercetange);

            // When
            var result = ClassUnderTest.Calculate(withdrawnAmount);

            // Then
            Assert.AreEqual(1, result);
        }
    }
}
