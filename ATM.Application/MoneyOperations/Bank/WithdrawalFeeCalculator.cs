using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Configuration;

namespace ATM.Application.MoneyOperations.Bank
{
    public class WithdrawalFeeCalculator : IWithdrawalFeeCalculator
    {
        private readonly IConfiguration _configuration;

        public WithdrawalFeeCalculator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public decimal Calculate(decimal withdrawnAmount)
        {
            return withdrawnAmount * _configuration.WithdrawalFeePercentage;
        }
    }
}
