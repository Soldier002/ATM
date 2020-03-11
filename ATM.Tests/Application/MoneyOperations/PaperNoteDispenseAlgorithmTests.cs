﻿using ATM.Application.Exceptions;
using ATM.Application.MoneyOperations.PaperNotes;
using ATM.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATM.Tests.Application.MoneyOperations
{
    [TestFixture]
    public class PaperNoteDispenseAlgorithmTests : AutoMockedTests<PaperNoteDispenseAlgorithm>
    {
        [Test]
        public void Given_cantUseHighestValueNotes_When_Dispense_Then_shouldReturnCorrectAmountsOfPaperNotes()
        {
            // Given
            var fifty = new PaperNote(50);
            var twenty = new PaperNote(20);
            var money = new Money
            {
                Amount = 110,
                Notes = new Dictionary<PaperNote, int>
                {
                    { fifty, 1 },
                    { twenty, 3 }
                }
            };
            var amountToDispense = 60;

            // When
            var result = ClassUnderTest.Dispense(amountToDispense, money);

            // Then
            Assert.AreEqual(60, result.Amount);
            Assert.AreEqual(1, result.Notes.Count);
            Assert.AreEqual(3, result.Notes[twenty]);
        }

        [Test]
        public void Given_manyVariationsAvailable_When_Dispense_Then_shouldUseHighestPossibleValuePaperNotes()
        {
            // Given
            var fifty = new PaperNote(50);
            var twenty = new PaperNote(20);
            var ten = new PaperNote(10);
            var money = new Money
            {
                Amount = 510,
                Notes = new Dictionary<PaperNote, int>
                {
                    { fifty, 5 },
                    { twenty, 3 },
                    { ten, 20 }
                }
            };
            var amountToDispense = 120;

            // When
            var result = ClassUnderTest.Dispense(amountToDispense, money);

            // Then
            Assert.AreEqual(120, result.Amount);
            Assert.AreEqual(2, result.Notes.Count);
            Assert.AreEqual(2, result.Notes[fifty]);
            Assert.AreEqual(1, result.Notes[twenty]);
        }

        [Test]
        public void Given_notEnoughMoneyInAtm_When_Dispense_Then_shouldThrowException()
        {
            // Given
            var moneyInAtm = new Money { Amount = 10 };
            var amountToDispense = 100;

            // When // Then
            Assert.Throws<NotEnoughMoneyInAtmException>(() => ClassUnderTest.Dispense(amountToDispense, moneyInAtm));
        }

        [Test]
        public void Given_paperNotesDontSumUpToAmount_When_Dispense_Then_shouldThrowException()
        {
            // Given
            var moneyInAtm = new Money
            {
                Amount = 100,
                Notes = new Dictionary<PaperNote, int>
                {
                    { new PaperNote(50), 1 },
                    { new PaperNote(20), 1 },
                    { new PaperNote(10), 3 }
                }
            };
            var amountToDispense = 55;

            // When // Then
            Assert.Throws<NecessaryPaperNotesNotAvailableException>(() => ClassUnderTest.Dispense(amountToDispense, moneyInAtm));
        }
        
    }
}
