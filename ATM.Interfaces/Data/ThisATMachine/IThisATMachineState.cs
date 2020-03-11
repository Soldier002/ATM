using ATM.Models;

namespace ATM.Interfaces.Data.ThisATMachine
{
    public interface IThisATMachineState
    {
        Money AvailableMoney { get; }

        string InsertedCardNumber { get; set; }
    }
}
