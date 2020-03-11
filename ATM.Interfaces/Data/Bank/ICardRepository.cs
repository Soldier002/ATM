using ATM.Models;

namespace ATM.Interfaces.Data.Bank
{
    public interface ICardRepository
    {
        Card Get(string cardNumber);
    }
}
