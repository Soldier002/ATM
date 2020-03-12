namespace ATM.Interfaces.Application.Configuration
{
    public interface IConfiguration
    {
        int[] AvailablePaperNoteFaceValues { get; }

        decimal WithdrawalFeePercentage { get; }
    }
}
