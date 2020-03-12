using ATM.Interfaces.Data.Bank;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ATM.Models.Bank;

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

        public IEnumerable<Fee> GetAll(string cardNumber)
        {
            var fees = _fees.Where(x => x.CardNumber == cardNumber);

            return fees;
        }
    }
}
