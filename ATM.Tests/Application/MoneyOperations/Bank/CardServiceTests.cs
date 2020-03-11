using ATM.Application.MoneyOperations.Bank;
using ATM.Data.Bank.Exceptions;
using ATM.Interfaces.Data;
using ATM.Models;
using NUnit.Framework;

namespace ATM.Tests.Application.MoneyOperations.Bank
{
    [TestFixture]
    public class CardServiceTests : AutoMockedTests<CardService>
    {
        [Test]
        public void Given_amount_When_Withdraw_Then_shouldWithdrawAmountFromCard()
        {
            // Given
            var amount = 100m;
            var cardNumber = "1234";
            var card = new Card { Balance = 100 };
            GetMock<ICardRepository>().Setup(x => x.Get(cardNumber)).Returns(card);

            // When
            ClassUnderTest.Withdraw(cardNumber, amount);

            // Then
            Assert.AreEqual(card.Balance, 0);
        }

        [Test]
        public void Given_amountIsBiggerThanCardBalance_When_Withdraw_Then_shouldThrowExceptionAndNotWithdraw()
        {
            // Given
            var amount = 150m;
            var cardNumber = "1234";
            var card = new Card { Balance = 100 };
            GetMock<ICardRepository>().Setup(x => x.Get(cardNumber)).Returns(card);

            // When // Then
            Assert.Throws<InsufficientFundsException>(() => ClassUnderTest.Withdraw(cardNumber, amount));
            Assert.AreEqual(100, card.Balance);
        }
    }
}
