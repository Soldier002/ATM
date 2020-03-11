using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.MoneyOperations.Bank;

namespace ATM.Application.Authorization
{
    public class CardReader : ICardReader
    {
        private static string _currentCardNumber;
        private readonly ICardService _cardService;

        public CardReader(ICardService cardService)
        {
            _cardService = cardService;
        }

        public string CurrentCardNumber => _currentCardNumber;

        public bool IsCardInserted => _currentCardNumber != null;

        public void Insert(string cardNumber)
        {
            if (!_cardService.CardExists(cardNumber))
            {
                throw new CardDoesNotExistException();
            }

            _currentCardNumber = cardNumber;
        }
    }
}
