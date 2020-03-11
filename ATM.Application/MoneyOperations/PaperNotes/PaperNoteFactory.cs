using ATM.Application.Exceptions;
using ATM.Interfaces.Application.MoneyOperations;
using ATM.Interfaces.Configuration;
using ATM.Models;
using System.Linq;

namespace ATM.Application.MoneyOperations.PaperNotes
{
    public class PaperNoteFactory : IPaperNoteFactory
    {
        private readonly IConfiguration _configuration;

        public PaperNoteFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PaperNote Create(int faceValue)
        {
            if (!_configuration.AvailablePaperNoteFaceValues.Contains(faceValue))
            {
                throw new PaperNoteFaceValueNotAvailableException();
            }

            return new PaperNote(faceValue);
        }
    }
}
