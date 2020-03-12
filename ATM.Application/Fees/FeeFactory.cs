using ATM.Interfaces.Application.Fees;
using ATM.Models;
using ATM.Interfaces.Application.Utility;
using ATM.Models.Bank;

namespace ATM.Application.Fees
{
    public class FeeFactory : IFeeFactory
    {
        private readonly IDateTimeFacade _dateTimeFacade;

        public FeeFactory(IDateTimeFacade dateTimeFacade)
        {
            _dateTimeFacade = dateTimeFacade;
        }

        public Fee Create(string cardNumber, decimal feeAmount)
        {
            var fee = new Fee
            {
                CardNumber = cardNumber,
                WithdrawalFeeAmount = feeAmount,
                WithdrawalDate = _dateTimeFacade.UtcNow()
            };

            return fee;

        }
    }
}
