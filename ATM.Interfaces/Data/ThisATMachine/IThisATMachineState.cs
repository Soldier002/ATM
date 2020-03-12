﻿using ATM.Models;
using ATM.Models.Finances;

namespace ATM.Interfaces.Data.ThisATMachine
{
    public interface IThisATMachineState
    {
        Money AvailableMoney { get; }

        string InsertedCardNumber { get; set; }

        bool OutOfService { get; set; }

        bool AlarmEnabled { get; set; }
    }
}
