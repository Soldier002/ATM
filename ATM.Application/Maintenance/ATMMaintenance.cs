using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Interfaces.Maintenance;
using ATM.Models;
using ATM.Models.Finances;

namespace ATM.Application.Maintenance
{
    public class ATMMaintenance : IATMMaintenance
    {
        private readonly IThisATMachineState _thisATMachineState;
        private readonly IPrepareForOperatorAccessCommand _prepareForOperatorAccessCommand;
        private readonly IPaperNoteValidator _paperNoteValidator;

        public ATMMaintenance(IThisATMachineState thisATMachineState, IPrepareForOperatorAccessCommand prepareForOperatorAccessCommand,
            IPaperNoteValidator paperNoteValidator)
        {
            _thisATMachineState = thisATMachineState;
            _prepareForOperatorAccessCommand = prepareForOperatorAccessCommand;
            _paperNoteValidator = paperNoteValidator;
        }

        public bool IsATMOutOfService => _thisATMachineState.OutOfService;

        public void LoadMoney(Money money)
        {
            _prepareForOperatorAccessCommand.Do();
            _paperNoteValidator.ValidateMany(money.Notes.Keys);
            foreach (var kvp in money.Notes)
            {
                if (_thisATMachineState.AvailableMoney.Notes.ContainsKey(kvp.Key))
                {
                    _thisATMachineState.AvailableMoney.Notes[kvp.Key] += kvp.Value;
                }
                else
                {
                    _thisATMachineState.AvailableMoney.Notes.Add(kvp.Key, kvp.Value);
                }
            }

            _prepareForOperatorAccessCommand.Undo();
        }
    }
}
