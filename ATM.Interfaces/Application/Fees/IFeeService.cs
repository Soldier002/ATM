using ATM.Models;
using System.Collections.Generic;

namespace ATM.Interfaces.Application.Fees
{
    public interface IFeeService
    {
        IEnumerable<Fee> GetAll(string cardNumber);
    }
}
