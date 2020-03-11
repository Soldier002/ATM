using ATM.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Tests.Models
{
    [TestFixture]
    public class PaperNoteTests
    {
        public void Given_twoPaperNotesWithSameFaceValue_When_Equals_Then_shouldReturnTrue()
        {
            // Given
            var paperNoteOne = new PaperNote(5);
            var paperNoteTwo = new PaperNote(5);

            // When
            var result = paperNoteOne.Equals(paperNoteTwo);

            // Then
            Assert.IsTrue(result);
        }

        public void Given_twoPaperNotesWithDifferentFaceValues_When_Equals_Then_shouldReturnFalse()
        {
            // Given
            var paperNoteOne = new PaperNote(5);
            var paperNoteTwo = new PaperNote(10);

            // When
            var result = paperNoteOne.Equals(paperNoteTwo);

            // Then
            Assert.IsFalse(result);
        }

        public void Given_paperNote_When_GetHashCode_Then_hashCodeIsFaceValue()
        {
            // Given
            var paperNote = new PaperNote(10);

            // When
            var result = paperNote.GetHashCode();

            // Then
            Assert.AreEqual(paperNote.FaceValue, result);
        }
    }
}
