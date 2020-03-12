using AutoFixture;
using ATM.Application.Maintenance;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Interfaces.Maintenance;
using ATM.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using ATM.Models.Finances;

namespace ATM.Tests.Application.Maintenance
{
    [TestFixture]
    public class ATMMaintenanceTests : AutoMockedTests<ATMMaintenance>
    {
        [Test]
        public void Given_money_When_LoadMoney_Then_shouldEnterMaintenanceModeAndSumMoneyCorrectly()
        {
            // Given
            var money = new Money
            {
                Notes = new Dictionary<PaperNote, int>()
                {
                    { new PaperNote(5), 2 },
                    { new PaperNote(10), 1 },
                    { new PaperNote(20), 4 }
                }
            };
            var moneyInAtm = new Money
            {
                Notes = new Dictionary<PaperNote, int>()
                {
                    { new PaperNote(5), 1 },
                    { new PaperNote(10), 1 }
                }
            };
            GetMock<IThisATMachineState>().Setup(x => x.AvailableMoney).Returns(moneyInAtm);

            var mockPrepareForOperatorAccessCommand = GetMock<IPrepareForOperatorAccessCommand>();
            var mockPaperNoteValidator = GetMock<IPaperNoteValidator>();

            // When
            ClassUnderTest.LoadMoney(money);

            // Then
            mockPrepareForOperatorAccessCommand.Verify(x => x.Do(), Times.Once);
            mockPrepareForOperatorAccessCommand.Verify(x => x.Undo(), Times.Once);
            mockPaperNoteValidator.Verify(x => x.ValidateMany(money.Notes.Keys), Times.Once);
            Assert.AreEqual(3, moneyInAtm.Notes.Count);
            Assert.AreEqual(3, moneyInAtm.Notes[new PaperNote(5)]);
            Assert.AreEqual(2, moneyInAtm.Notes[new PaperNote(10)]);
            Assert.AreEqual(4, moneyInAtm.Notes[new PaperNote(20)]);
        }

        [Test]
        public void Given_nothing_When_IsATMOutOfService_Then_shouldReturnIt()
        {
            // Given
            var outOfService = Fixture.Create<bool>();
            GetMock<IThisATMachineState>().Setup(x => x.OutOfService).Returns(outOfService);

            // When
            var result = ClassUnderTest.IsATMOutOfService;

            // Then
            Assert.AreEqual(outOfService, result);
        }
    }
}
