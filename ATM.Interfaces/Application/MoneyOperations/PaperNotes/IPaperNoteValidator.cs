using ATM.Models;
using ATM.Models.Finances;
using System.Collections.Generic;

namespace ATM.Interfaces.Application.MoneyOperations.PaperNotes
{
    public interface IPaperNoteValidator
    {
        void ValidateMany(IEnumerable<PaperNote> paperNotes);
    }
}
