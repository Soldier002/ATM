using ATM.Models;

namespace ATM.Interfaces.Application.Fees
{
    public interface IFeeFactory
    {
        Fee Create(string cardNumber, decimal feeAmount);
    }
}
