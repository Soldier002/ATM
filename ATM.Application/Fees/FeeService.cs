using ATM.Interfaces.Application.Fees;
using System.Collections.Generic;
using ATM.Interfaces.Data.Bank;
using ATM.Models.Bank;

namespace ATM.Application.Fees
{
    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _feeRepository;

        public FeeService(IFeeRepository feeRepository)
        {
            _feeRepository = feeRepository;
        }

        public IEnumerable<Fee> GetAll(string cardNumber)
        {
            var fees = _feeRepository.GetAll(cardNumber);

            return fees;
        }
    }
}
