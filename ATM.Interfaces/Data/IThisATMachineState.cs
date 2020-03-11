using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces.Data
{
    public interface IThisATMachineState
    {
        Money AvailableMoney { get; }
    }
}
