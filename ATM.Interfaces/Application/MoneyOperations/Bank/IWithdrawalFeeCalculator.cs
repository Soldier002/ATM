namespace ATM.Interfaces.Application.MoneyOperations.Bank
{
    public interface IWithdrawalFeeCalculator
    {
        decimal Calculate(decimal withdrawnAmount);
    }
}
