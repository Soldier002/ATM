using ATM.Interfaces.Data.ThisATMachine;
using ATM.Models;
using System.Diagnostics.CodeAnalysis;

namespace ATM.Data.ThisATMachine
{
    [ExcludeFromCodeCoverage]
    public class InMemoryThisATMachineState : IThisATMachineState
    {
        private readonly static ATMStatusModel _atmStatus = new ATMStatusModel
        {
            AvailableMoney = new Money(),
            OutOfService = false,
            AlarmEnabled = true
        };

        public Money AvailableMoney
        {
            get { return _atmStatus.AvailableMoney; }
            set { _atmStatus.AvailableMoney = value; }
        }

        public string InsertedCardNumber
        {
            get { return _atmStatus.InsertedCardNumber; }
            set { _atmStatus.InsertedCardNumber = value; }
        }

        public bool OutOfService
        {
            get { return _atmStatus.OutOfService; }
            set { _atmStatus.OutOfService = value; }
        }

        public bool AlarmEnabled
        {
            get { return _atmStatus.AlarmEnabled;  }
            set { _atmStatus.AlarmEnabled = value; }
        }
    }
}
