using ATM.Application.MoneyOperations.Bank;
using ATM.Data.Bank.Exceptions;
using ATM.Interfaces.Application.Fees;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Data.Bank;
using ATM.Models;
using AutoFixture;
using Moq;
using NUnit.Framework;

namespace ATM.Tests.Application.MoneyOperations.Bank
{
    [TestFixture]
    public class CardServiceTests : AutoMockedTests<CardService>
    {
        [Test]
        public void Given_amount_When_Withdraw_Then_shouldWithdrawAmountFromCardAndSaveFee()
        {
            // Given
            var amount = 90m;
            var feeAmount = 10m;
            var cardNumber = Fixture.Create<string>();
            var fee = Fixture.Create<Fee>();
            var card = new Card { Balance = 100 };
            GetMock<ICardRepository>().Setup(x => x.Get(cardNumber)).Returns(card);
            GetMock<IWithdrawalFeeCalculator>().Setup(x => x.Calculate(amount)).Returns(feeAmount);
            GetMock<IFeeFactory>().Setup(x => x.Create(cardNumber, feeAmount)).Returns(fee);
            var mockFeeRepository = GetMock<IFeeRepository>();

            // When
            ClassUnderTest.Withdraw(cardNumber, amount);

            // Then
            Assert.AreEqual(card.Balance, 0);
            mockFeeRepository.Verify(x => x.Add(fee), Times.Once);
        }

        [Test]
        public void Given_amountIsBiggerThanCardBalance_When_Withdraw_Then_shouldThrowExceptionAndNotWithdraw()
        {
            // Given
            var amount = 150m;
            var cardNumber = Fixture.Create<string>();
            var card = new Card { Balance = 100 };
            GetMock<ICardRepository>().Setup(x => x.Get(cardNumber)).Returns(card);

            // When // Then
            Assert.Throws<InsufficientFundsException>(() => ClassUnderTest.Withdraw(cardNumber, amount));
            Assert.AreEqual(100, card.Balance);
        }

        [Test]
        public void Given_cardNumber_When_GetCardBalance_Then_shouldReturnBalanceOfTheCard()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            var card = Fixture.Create<Card>();
            GetMock<ICardRepository>().Setup(x => x.Get(cardNumber)).Returns(card);

            // When
            var result = ClassUnderTest.GetCardBalance(cardNumber);

            // Then
            Assert.AreEqual(card.Balance, result);
        }

        [Test]
        public void Given_cardNumber_When_CardExists_Then_shouldCheckIfCardExists()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            var cardExists = Fixture.Create<bool>();
            GetMock<ICardRepository>().Setup(x => x.CardExists(cardNumber)).Returns(cardExists);

            // When
            var result = ClassUnderTest.CardExists(cardNumber);

            // Then
            Assert.AreEqual(cardExists, result);
        }
    }
}
