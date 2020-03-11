using ATM.Interfaces.Application.Authorization;
using ATM.Models;

namespace ATM.Application.Authorization
{
    public class CardReader : ICardReader
    {
        private static Card _currentCard;

        public bool IsCardInserted()
        {
            return _currentCard != null;
        }

        public void Insert(Card card)
        {
            _currentCard = card;
        }
    }
}
