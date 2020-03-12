using ATM.Application.MoneyOperations.Exceptions;
using ATM.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Models.Finances;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATM.Tests.Application.MoneyOperations.PaperNotes
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
                Notes = new Dictionary<PaperNote, int>
                {
                    { fifty, 1 },
                    { twenty, 3 }
                }
            };
            var amountToDispense = 60;
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(money);

            // When
            var result = ClassUnderTest.Dispense(amountToDispense);

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
                Notes = new Dictionary<PaperNote, int>
                {
                    { fifty, 5 },
                    { twenty, 3 },
                    { ten, 20 }
                }
            };
            var amountToDispense = 120;
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(money);

            // When
            var result = ClassUnderTest.Dispense(amountToDispense);

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
            var moneyInAtm = new Money
            {
                Notes = new Dictionary<PaperNote, int>
                {
                    { new PaperNote(5), 1 }
                }
            };
            var amountToDispense = 100;
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(moneyInAtm);

            // When // Then
            Assert.Throws<NotEnoughMoneyInAtmException>(() => ClassUnderTest.Dispense(amountToDispense));
        }

        [Test]
        public void Given_paperNotesDontSumUpToAmount_When_Dispense_Then_shouldThrowException()
        {
            // Given
            var moneyInAtm = new Money
            {
                Notes = new Dictionary<PaperNote, int>
                {
                    { new PaperNote(50), 1 },
                    { new PaperNote(20), 1 },
                    { new PaperNote(10), 3 }
                }
            };
            var amountToDispense = 55;
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(moneyInAtm);

            // When // Then
            Assert.Throws<NecessaryPaperNotesNotAvailableException>(() => ClassUnderTest.Dispense(amountToDispense));
        }
        
    }
}
