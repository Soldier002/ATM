using ATM.Application.MoneyOperations.Exceptions;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Configuration;
using ATM.Models;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Application.MoneyOperations.PaperNotes
{
    public class PaperNoteValidator : IPaperNoteValidator
    {
        private readonly IConfiguration _configuration;

        public PaperNoteValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ValidateMany(IEnumerable<PaperNote> paperNotes)
        {
            foreach (var paperNote in paperNotes)
            {
                if (!_configuration.AvailablePaperNoteFaceValues.Contains(paperNote.FaceValue))
                {
                    throw new PaperNoteFaceValueNotAvailableException();
                }
            }
        }
    }
}
