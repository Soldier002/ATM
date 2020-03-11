﻿using ATM.Models;
using System.Collections.Generic;

namespace ATM.Interfaces.Data.Bank
{
    public interface IFeeRepository
    {
        void Add(Fee fee);

        IEnumerable<Fee> GetAll(string cardNumber);
    }
}
