using ATM.Models;

namespace ATM.Interfaces.Application.MoneyOperations
{
    public interface IPaperNoteFactory
    {
        PaperNote Create(int faceValue);
    }
}
