using ATM.Models.Bank;

namespace ATM.Interfaces.Application.Fees
{
    public interface IFeeFactory
    {
        Fee Create(string cardNumber, decimal feeAmount);
    }
}
