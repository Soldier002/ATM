using ATM.Models;
using ATM.Models.Bank;
using System.Collections.Generic;

namespace ATM.Interfaces.Application.Fees
{
    public interface IFeeService
    {
        IEnumerable<Fee> GetAll(string cardNumber);
    }
}
