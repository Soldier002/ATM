using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces.Application.MoneyOperations.Bank
{
    public interface IWithdrawalFeeCalculator
    {
        decimal Calculate(decimal withdrawnAmount);
    }
}
