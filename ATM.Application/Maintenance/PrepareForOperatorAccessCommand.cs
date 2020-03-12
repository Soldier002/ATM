using ATM.Interfaces.Application.Maintenance;
using ATM.Interfaces.Data.ThisATMachine;

namespace ATM.Application.Maintenance
{
    public class PrepareForOperatorAccessCommand : IPrepareForOperatorAccessCommand
    {
        private readonly IThisATMachineState _thisATMachineState;

        public PrepareForOperatorAccessCommand(IThisATMachineState thisATMachineState)
        {
            _thisATMachineState = thisATMachineState;
        }

        public void Do()
        {
            _thisATMachineState.AlarmEnabled = false;
            _thisATMachineState.OutOfService = true;
        }

        public void Undo()
        {
            _thisATMachineState.AlarmEnabled = true;
            _thisATMachineState.OutOfService = false;
        }
    }
}
