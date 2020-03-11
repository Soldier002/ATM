using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Application.MoneyOperations.Exceptions;
using ATM.Interfaces.Data.ThisATMachine;

namespace ATM.Application.MoneyOperations.PaperNotes
{
    public class PaperNoteDispenseAlgorithm : IPaperNoteDispenseAlgorithm
    {
        private int[] resultVariation;
        private readonly IThisATMachineState _thisATMachineState;

        public PaperNoteDispenseAlgorithm(IThisATMachineState thisATMachineState)
        {
            _thisATMachineState = thisATMachineState;
        }

        public Money Dispense(int amountToDispense)
        {
            var moneyInAtm = _thisATMachineState.AvailableMoney;
            if (amountToDispense > moneyInAtm.Amount)
            {
                throw new NotEnoughMoneyInAtmException();
            }

            var orderedPaperNoteAmounts = moneyInAtm.Notes.OrderByDescending(x => x.Key.FaceValue).ToList();

            RunThroughVariations(new int[orderedPaperNoteAmounts.Count], 0, orderedPaperNoteAmounts, amountToDispense);

            if (resultVariation == null)
            {
                throw new NecessaryPaperNotesNotAvailableException();
            }

            var money = new Money
            {
                Amount = amountToDispense,
                Notes = new Dictionary<PaperNote, int>()
            };

            for (var i = 0; i < orderedPaperNoteAmounts.Count; i++)
            {
                if (resultVariation[i] > 0)
                {
                    money.Notes.Add(orderedPaperNoteAmounts[i].Key, resultVariation[i]);
                }
            }

            return money;
        }

        private void RunThroughVariations(int[] variation, int position, List<KeyValuePair<PaperNote, int>> orderedPaperNoteAmounts, int amountToDispense)
        {
            if (resultVariation != null)
            {
                return;
            }

            var sum = GetCurrentSum(variation, orderedPaperNoteAmounts);
            if (sum < amountToDispense)
            {
                for (var i = position; i < orderedPaperNoteAmounts.Count; i++)
                {
                    if (variation[i] < orderedPaperNoteAmounts[i].Value)
                    {
                        var nextVariation = (int[])variation.Clone();
                        nextVariation[i]++;
                        RunThroughVariations(nextVariation, i, orderedPaperNoteAmounts, amountToDispense);
                    }
                }
            }
            else if (sum == amountToDispense)
            {
                resultVariation = variation;
            }
        }

        private int GetCurrentSum(int[] variation, List<KeyValuePair<PaperNote, int>> orderedPaperNoteAmounts)
        {
            var sum = 0;
            for (var i = 0; i < variation.Length; i++)
            {
                sum += orderedPaperNoteAmounts[i].Key.FaceValue * variation[i];
            }

            return sum;
        }
    }
}
