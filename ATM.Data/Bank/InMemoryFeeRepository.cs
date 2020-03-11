using ATM.Interfaces.Data.Bank;
using System.Collections.Generic;
using ATM.Models;
using System.Diagnostics.CodeAnalysis;

namespace ATM.Data.Bank
{
    [ExcludeFromCodeCoverage]
    public class InMemoryFeeRepository : IFeeRepository
    {
        private static List<Fee> _fees = new List<Fee>();

        public void Add(Fee fee)
        {
            _fees.Add(fee);
        }
    }
}
