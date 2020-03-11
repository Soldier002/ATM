using ATM.Models;

namespace ATM.Interfaces.Application.MoneyOperations
{
    public interface IPaperNoteDispenseAlgorithm
    {
        Money Dispense(int amountToDispense, Money moneyInAtm);
    }
}
