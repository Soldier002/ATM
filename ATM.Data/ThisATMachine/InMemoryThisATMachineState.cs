using ATM.Interfaces.Data.ThisATMachine;
using ATM.Models;
using System.Diagnostics.CodeAnalysis;

namespace ATM.Data.ThisATMachine
{
    [ExcludeFromCodeCoverage]
    public class InMemoryThisATMachineState : IThisATMachineState
    {
        private static Money _availableMoney = new Money();

        public Money AvailableMoney => _availableMoney;

        public string InsertedCardNumber { get; set; }
    }
}
