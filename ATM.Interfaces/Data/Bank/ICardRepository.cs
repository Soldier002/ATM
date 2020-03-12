using ATM.Models.Bank;

namespace ATM.Interfaces.Data.Bank
{
    public interface ICardRepository
    {
        Card Get(string cardNumber);

        bool CardExists(string cardNumber);
    }
}
