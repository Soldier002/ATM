using ATM.Models;

namespace ATM.Interfaces.Data
{
    public interface ICardRepository
    {
        Card Get(string cardNumber);
    }
}
