using ATM.Application.Exceptions;
using ATM.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Configuration;
using NUnit.Framework;

namespace ATM.Tests.Application.MoneyOperations
{
    [TestFixture]
    public class PaperNoteFactoryTests : AutoMockedTests<PaperNoteFactory>
    {
        [Test]
        public void Given_notAvailablePaperNote_When_Create_Then_shouldThrowException()
        {
            // Given
            var faceValue = 7;
            GetMock<IConfiguration>().Setup(x => x.AvailablePaperNoteFaceValues).Returns(new int[] { 5, 10 });

            // When // Then
            Assert.Throws<PaperNoteFaceValueNotAvailableException>(() => ClassUnderTest.Create(faceValue));
        }

        [Test]
        public void Given_availablePaperNote_When_Create_Then_shouldReturnPaperNoteWithThatFaceValue()
        {
            // Given
            var faceValue = 5;
            GetMock<IConfiguration>().Setup(x => x.AvailablePaperNoteFaceValues).Returns(new int[] { 5, 10 });

            // When
            var result = ClassUnderTest.Create(faceValue);

            // Then
            Assert.AreEqual(faceValue, result.FaceValue);
        }
    }
}
