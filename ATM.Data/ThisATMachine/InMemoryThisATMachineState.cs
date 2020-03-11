using ATM.Interfaces.Data;
using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Data.ThisATMachine
{
    public class InMemoryThisATMachineState : IThisATMachineState
    {
        private static Money _availableMoney = new Money();

        public Money AvailableMoney => _availableMoney;
    }
}
