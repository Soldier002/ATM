using System.Collections.Generic;
using System.Linq;
using ATM.Interfaces.Data.Bank;
using System.Diagnostics.CodeAnalysis;
using ATM.Models.Bank;

namespace ATM.Data.Bank
{
    [ExcludeFromCodeCoverage]
    public class InMemoryCardRepository : ICardRepository
    {
        private static List<Card> cards = new List<Card>
        {
            new Card
            {
                CardNumber = "4000300020001000",
                Balance = 1000
            }
        };

        public Card Get(string cardNumber)
        {
            var card = cards.First(x => x.CardNumber == cardNumber);

            return card;
        }

        public bool CardExists(string cardNumber)
        {
            var cardExists = cards.Any(x => x.CardNumber == cardNumber);

            return cardExists;
        }
    }
}
