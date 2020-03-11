using ATM.Models;

namespace ATM.Interfaces.Application.MoneyOperations.PaperNotes
{
    public interface IPaperNoteDispenseAlgorithm
    {
        Money Dispense(int amountToDispense);
    }
}
