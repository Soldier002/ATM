using ATM.Models;

namespace ATM.Interfaces.Data
{
    public interface IThisATMachineState
    {
        Money AvailableMoney { get; }
    }
}
