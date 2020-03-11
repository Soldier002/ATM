﻿using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Data;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Models;
using AutoFixture;
using Moq;
using NUnit.Framework;

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
            GetMock<ICardReader>().Setup(x => x.IsCardInserted()).Returns(false);

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

            GetMock<ICardReader>().Setup(x => x.IsCardInserted()).Returns(true);
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(availableMoney);
            GetMock<IPaperNoteDispenseAlgorithm>().Setup(x => x.Dispense(amountToDispense, availableMoney)).Returns(withdrawnMoney);
            GetMock<ICardReader>().Setup(x => x.CurrentCardNumber).Returns(cardNumber);
            var cardServiceMock = GetMock<ICardService>();

            // When 
            var result = ClassUnderTest.WithdrawMoney(amountToDispense);

            // Then
            cardServiceMock.Verify(x => x.Withdraw(cardNumber, amountToDispense), Times.Once);
            Assert.AreEqual(withdrawnMoney, result);
        }
    }
}
