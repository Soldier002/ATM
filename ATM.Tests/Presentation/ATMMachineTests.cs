using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.Fees;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Models;
using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATM.Tests.Presentation
{
    [TestFixture]
    public class ATMMachineTests : AutoMockedTests<ATMachine>
    {
        [Test]
        public void Given_cardNotInserted_When_WithdrawMoney_Then_shouldThrowException()
        {
            // Given
            var amount = Fixture.Create<int>();
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(false);

            // When // Then
            Assert.Throws<CardNotInsertedException>(() => ClassUnderTest.WithdrawMoney(amount));
        }

        [Test]
        public void Given_cardInserted_When_WithdrawMoney_Then_shouldProceed()
        {
            // Given 
            var amountToDispense = Fixture.Create<int>();
            var availableMoney = Fixture.Create<Money>();
            var withdrawnMoney = Fixture.Create<Money>();
            var cardNumber = Fixture.Create<string>();

            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(true);
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(availableMoney);
            GetMock<IPaperNoteDispenseAlgorithm>().Setup(x => x.Dispense(amountToDispense, availableMoney)).Returns(withdrawnMoney);
            GetMock<ICardReader>().Setup(x => x.InsertedCardNumber).Returns(cardNumber);
            var mockCardService = GetMock<ICardService>();

            // When 
            var result = ClassUnderTest.WithdrawMoney(amountToDispense);

            // Then
            mockCardService.Verify(x => x.Withdraw(cardNumber, amountToDispense), Times.Once);
            Assert.AreEqual(withdrawnMoney, result);
        }

        [Test]
        public void Given_cardNotInserted_When_RetrieveChargedFees_Then_shouldThrowException()
        {
            // Given
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(false);

            // When // Then
            Assert.Throws<CardNotInsertedException>(() => ClassUnderTest.RetrieveChargedFees());
        }

        [Test]
        public void Given_cardInserted_When_RetrieveChargedFees_Then_shouldReturnFees()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            var fees = new List<Fee>();
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(true);
            GetMock<ICardReader>().Setup(x => x.InsertedCardNumber).Returns(cardNumber);
            GetMock<IFeeService>().Setup(x => x.GetAll(cardNumber)).Returns(fees);

            // When
            var result = ClassUnderTest.RetrieveChargedFees();

            // Then
            Assert.AreEqual(fees, result);
        }

        [Test]
        public void Given_cardAlreadyInserted_When_InsertCard_Then_shouldThrowException()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(true);

            // When // Then
            Assert.Throws<CardAlreadyInsertedException>(() => ClassUnderTest.InsertCard(cardNumber));
        }

        [Test]
        public void Given_cardNumber_When_InsertCard_Then_shouldInsertCard()
        {
            // Given
            var cardNumber = Fixture.Create<string>();
            var mockCardReader = GetMock<ICardReader>();

            // When
            ClassUnderTest.InsertCard(cardNumber);

            // Then
            mockCardReader.Verify(x => x.Insert(cardNumber), Times.Once);
        }

        [Test]
        public void Given_cardNotInserted_When_ReturnCard_Then_shouldThrowException()
        {
            // Given
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(false);

            // When // Then
            Assert.Throws<CardNotInsertedException>(() => ClassUnderTest.ReturnCard());
        }

        [Test]
        public void Given_cardInserted_When_ReturnCard_Then_shouldReturnCard()
        {
            // Given
            GetMock<ICardReader>().Setup(x => x.IsCardInserted).Returns(true);
            var cardReaderMock = GetMock<ICardReader>();

            // When
            ClassUnderTest.ReturnCard();

            // Then
            cardReaderMock.Verify(x => x.Remove(), Times.Once);
        }
    }
}
