using ATM.Interfaces.Authorization;
using ATM.Models;
using System;

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
