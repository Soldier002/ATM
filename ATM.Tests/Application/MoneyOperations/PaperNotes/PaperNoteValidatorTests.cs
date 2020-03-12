using ATM.Application.MoneyOperations.Exceptions;
using ATM.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Configuration;
using ATM.Models;
using ATM.Models.Finances;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATM.Tests.Application.MoneyOperations.PaperNotes
{
    [TestFixture]
    public class PaperNoteValidatorTests : AutoMockedTests<PaperNoteValidator>
    {
        [Test]
        public void Given_containsNotAvailablePaperNote_When_ValidateMany_Then_shouldThrowException()
        {
            // Given
            var paperNotes = new List<PaperNote> { new PaperNote(7) };
            GetMock<IConfiguration>().Setup(x => x.AvailablePaperNoteFaceValues).Returns(new int[] { 5, 10 });

            // When // Then
            Assert.Throws<PaperNoteFaceValueNotAvailableException>(() => ClassUnderTest.ValidateMany(paperNotes));
        }

        [Test]
        public void Given_availablePaperNotes_When_ValidateMany_Then_shouldNotThrow()
        {
            // Given
            var paperNotes = new List<PaperNote> { new PaperNote(5) };
            GetMock<IConfiguration>().Setup(x => x.AvailablePaperNoteFaceValues).Returns(new int[] { 5, 10 });

            // When // Then
            Assert.DoesNotThrow(() => ClassUnderTest.ValidateMany(paperNotes));
        }
    }
}
