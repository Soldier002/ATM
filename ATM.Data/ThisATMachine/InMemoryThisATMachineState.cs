using ATM.Interfaces.Data;
using ATM.Models;

namespace ATM.Data.ThisATMachine
{
    public class InMemoryThisATMachineState : IThisATMachineState
    {
        private static Money _availableMoney = new Money();

        public Money AvailableMoney => _availableMoney;
    }
}
