using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Data;
using ATM.Data.Bank.Exceptions;

namespace ATM.Application.MoneyOperations.Bank
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Withdraw(string cardNumber, decimal amount)
        {
            var card = _cardRepository.Get(cardNumber);
            if (card.Balance - amount < 0)
            {
                throw new InsufficientFundsException();
            }

            card.Balance -= amount;
        }
    }
}
