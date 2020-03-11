using ATM.Interfaces.Configuration;

namespace ATM.Application.Configuration
{
    public class InMemoryConfiguration : IConfiguration
    {
        private int[] _availablePaperNoteFaceValues = new int[] { 5, 10, 20, 50 };
        private decimal _withdrawalFeePercentage = 0.01m;

        public int[] AvailablePaperNoteFaceValues => _availablePaperNoteFaceValues;

        public decimal WithdrawalFeePercentage => _withdrawalFeePercentage;
    }
}
